using System;
using Newtonsoft.Json;

namespace MojangApi
{
	public class YggdrasilProfile
	{
		[JsonProperty("id")]
		public string Id { get; set; } 

		[JsonProperty("name")]
		public string Name { get; set; } 

		[JsonProperty("legacy")]
		public bool Legacy { get; set; } 
	}
}

