using System;
using Newtonsoft.Json;

namespace MojangApi
{
	public class YggdrasilRefreshRequest
	{
		[JsonProperty("accessToken")]
		public string AccessToken { get; private set; } 

		[JsonProperty("clientToken")]
		public string ClientToken { get; private set; } 

		public YggdrasilRefreshRequest(string accessToken, string clientToken)
		{
			AccessToken = accessToken;
			ClientToken = clientToken;
		}
	}
}

