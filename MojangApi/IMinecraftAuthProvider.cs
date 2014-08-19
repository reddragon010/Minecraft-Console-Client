using System;

namespace MojangApi
{
	public interface IMinecraftAuthProvider
	{
		MinecraftLoginResult Login (MinecraftUser user);
		void Logout(MinecraftUser user);
	}
}

