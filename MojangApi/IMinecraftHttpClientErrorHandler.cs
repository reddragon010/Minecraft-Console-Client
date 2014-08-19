using System;
using System.Net;

namespace MojangApi
{
	public interface IMinecraftHttpClientErrorHandler
	{
		MinecraftAuthError HandleError(HttpWebResponse response);
	}
}

