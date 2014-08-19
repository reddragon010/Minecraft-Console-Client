using System;

namespace MojangApi
{
	public class MinecraftAuthError
	{
		public MinecraftLoginResult LoginResult { get; private set; }
		public string ErrorDescription { get; private set;  }
		public string ErrorCause { get; private set;  }

		public MinecraftAuthError(MinecraftLoginResult result, string description = null, string cause = null){
			LoginResult = result;
			ErrorDescription = description;
			ErrorCause = cause;
		}
	}
}

