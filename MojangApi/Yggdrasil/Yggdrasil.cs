using System;

namespace MojangApi
{
	public static class Yggdrasil
	{
		public const string HTTP_HEADER_CONTENTTYPE = "Content-Type: application/json";

		private const string AUTH_BASE_URL = "https://authserver.mojang.com";

		public const string AUTH_LOGIN_URL = AUTH_BASE_URL + "/authenticate";
		public const string AUTH_REFRESH_URL = AUTH_BASE_URL + "/refresh";

		private const string SESSION_BASE_URL = "https://sessionserver.mojang.com";

		public const string SESSION_JOIN_URL = SESSION_BASE_URL + "/session/minecraft/join";
	}
}

