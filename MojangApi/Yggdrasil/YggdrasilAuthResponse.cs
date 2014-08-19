using System;
using Newtonsoft.Json;

namespace MojangApi
{
	public class YggdrasilAuthResponse
	{
		[JsonProperty("accessToken")]
		public string AccessToken { get; set; } 

		[JsonProperty("clientToken")]
		public string ClientToken { get; set; } 

		[JsonProperty("availableProfiles")]
		public YggdrasilProfile[] AvailableProfiles { get; set; } 

		[JsonProperty("selectedProfile")]
		public YggdrasilProfile SelectedProfile { get; set; } 
	}
}

