using System;

namespace MojangApi
{
	public interface IMinecraftSessionProvider
	{
		bool JoinServer(MinecraftUser user, MinecraftServer server);
	}
}

