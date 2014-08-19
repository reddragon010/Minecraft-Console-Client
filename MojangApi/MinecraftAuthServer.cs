using System;

namespace MojangApi
{
	public class MinecraftAuthServer
	{
		private IMinecraftAuthProvider provider;

		public MinecraftAuthServer (IMinecraftAuthProvider authProvider)
		{
			provider = authProvider;
		}

		public void Login(MinecraftUser login)
		{
			provider.Login (login);
		}

		public void Logout(MinecraftUser login)
		{
			provider.Logout (login);
		}
	}
}

