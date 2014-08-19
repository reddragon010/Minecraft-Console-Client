using System;
using System.Net;

namespace MojangApi
{
	public interface IMinecraftHttpClient
	{
		bool PostAndTryGetResult<TRequest, TResponse> (string url, TRequest request, out TResponse response)
			where TResponse : class;

		MinecraftAuthError GetLastError();
	}
}

