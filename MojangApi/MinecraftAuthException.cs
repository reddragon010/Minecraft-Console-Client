using System;

namespace MojangApi
{
	public class MinecraftAuthException : Exception
	{
		public MinecraftAuthError Error { get; private set; }

		public MinecraftAuthException (MinecraftAuthError error, Exception inner = null)
			:base(error.ErrorDescription, inner)
		{
			Error = error;
		}
	}
}

