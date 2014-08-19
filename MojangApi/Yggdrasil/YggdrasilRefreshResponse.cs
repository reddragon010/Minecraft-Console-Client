using System;
using Newtonsoft.Json;

namespace MojangApi
{
	public class YggdrasilRefreshResponse
	{
		[JsonProperty("accessToken")]
		public string AccessToken { get; set; }

		[JsonProperty("clientToken")]
		public string ClientToken { get; set; }

		[JsonProperty("selectedProfile")]
		public YggdrasilProfile SelectedProfile { get; set; }
	}
}

