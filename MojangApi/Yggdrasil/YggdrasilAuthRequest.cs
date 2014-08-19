using System;
using Newtonsoft.Json;

namespace MojangApi
{
	public class YggdrasilAuthRequest
	{
		[JsonProperty("agent")]
		public YggdrasilAuthRequestAgent Agent { get; set; }

		[JsonProperty("username")]
		public string Username { get; private set; }

		[JsonProperty("password")]
		public string Password { get; private set; }

		[JsonProperty("clientToken")]
		public string ClientToken { get; private set; }

		public YggdrasilAuthRequest(string username, string password, string clientToken)
		{
			Username = username;
			Password = password;
			ClientToken = clientToken;

			Agent = new YggdrasilAuthRequestAgent();
		}


	}
}

