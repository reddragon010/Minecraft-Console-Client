using System;
using Newtonsoft.Json;

namespace MojangApi
{
	public class YggdrasilAuthError
	{
		[JsonProperty("error")]
		public string Error;

		[JsonProperty("cause")]
		public string Cause;

		[JsonProperty("errorMessage")]
		public string ErrorMessage;
	}
}

