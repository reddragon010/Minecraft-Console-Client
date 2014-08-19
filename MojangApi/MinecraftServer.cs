using System;
using System.Net;

namespace MojangApi
{
	public class MinecraftServer
	{
		public string ServerId {
			get;
			private set;
		}

		public string ServerDescription {
			get;
			private set;
		}

		public IPAddress ServerAddress {
			get;
			private set;
		}

		public MinecraftServer (string serverId, IPAddress serverAddress, string serverDescription=null)
		{
			ServerId = serverId;
			ServerAddress = serverAddress;
			ServerDescription = serverDescription;
		}
	}
}

