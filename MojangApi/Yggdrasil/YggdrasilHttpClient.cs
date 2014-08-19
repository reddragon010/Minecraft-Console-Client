using System;
using System.Net;

namespace MojangApi
{
	public class YggdrasilHttpClient
	{
		protected WebClient wsClient;

		public YggdrasilHttpClient ()
		{
			wsClient = new WebClient();
			wsClient.Headers.Add(Yggdrasil.HTTP_HEADER_CONTENTTYPE);
		}

		public YggdrasilHttpClient (WebClient webClient)
		{
			wsClient = webClient;
		}

		protected virtual string SubmitRequest<TRequest>(string url, TRequest request)
		{
			try
			{
				string jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject (request);
				return wsClient.UploadString (url, jsonRequest);
			}
			catch (WebException e)
			{
				HttpWebResponse rawResponse = (HttpWebResponse)e.Response;
				MinecraftAuthError error = HandleError (rawResponse);
				throw new MinecraftAuthException(error);
			}
		}

		protected virtual TResponse SubmitRequest<TResponse, TRequest>(string url, TRequest request)
		{
			string jsonResponse = SubmitRequest<TRequest>(url, request);
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse> (jsonResponse);
		}

		private MinecraftAuthError HandleError (System.Net.HttpWebResponse response)
		{
			if (response.ContentLength > 0)
			{
				using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
				{
					string result = sr.ReadToEnd();
					try{
						YggdrasilAuthError error = Newtonsoft.Json.JsonConvert.DeserializeObject<YggdrasilAuthError>(result);
						return new MinecraftAuthError (ParseLoginResult(error), error.ErrorMessage, error.Cause);
					} catch (Exception){
						return new MinecraftAuthError (MinecraftLoginResult.OtherError, response.StatusDescription);
					}
				}
			}
			else if ((int)response.StatusCode == 503)
				return new MinecraftAuthError(MinecraftLoginResult.ServiceUnavailable);

			return new MinecraftAuthError(MinecraftLoginResult.Blocked);
		}

		private MinecraftLoginResult ParseLoginResult(YggdrasilAuthError error) {
			switch (error.Error) {
			case "ForbiddenOperationException":
				return (error.Cause == "UserMigratedException" ? MinecraftLoginResult.AccountMigrated : MinecraftLoginResult.WrongPassword);
			case "Method Not Allowed":
			case "Not Found":
			case "IllegalArgumentException":
			case "Unsupported Media Type":
			default:
				return MinecraftLoginResult.OtherError;
			}
		}

		protected string GetClientToken()
		{
			string hostName = Dns.GetHostName ();
			string userName = System.Environment.UserName;
			using (System.Security.Cryptography.SHA1Managed sha1 = new System.Security.Cryptography.SHA1Managed())
			{
				using(System.IO.MemoryStream ms = new System.IO.MemoryStream (System.Text.UTF8Encoding.UTF8.GetBytes (hostName + userName)))
				{
					var hash = sha1.ComputeHash(ms);
					return Convert.ToBase64String(hash);
				}
			}
		}
	}
}

