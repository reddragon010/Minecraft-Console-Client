using System;
using System.Net;

namespace MojangApi
{
	public class YggdrasilSessionProvider : YggdrasilHttpClient, IMinecraftSessionProvider
	{
		public YggdrasilSessionProvider () 
		{}

		public YggdrasilSessionProvider (WebClient wsClient) 
			: base(wsClient)
		{}
			
		#region IMinecraftSessionProvider implementation
		public bool JoinServer (MinecraftUser user, MinecraftServer server)
		{
			YggdrasilSessionJoinRequest request = new YggdrasilSessionJoinRequest (user.AuthToken, user.SelectedProfile.Id, server.ServerId);
			string response = SubmitRequest<YggdrasilSessionJoinRequest> (Yggdrasil.SESSION_JOIN_URL, request);
			return (response == "");
		}
		#endregion
	}
}

