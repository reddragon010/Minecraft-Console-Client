using System;
using Newtonsoft.Json;

namespace MojangApi
{
	public class YggdrasilAuthRequestAgent
	{
		[JsonProperty("name")]
		public string Name = "Minecraft";

		[JsonProperty("version")]
		public int Version = 1;
	}
}

