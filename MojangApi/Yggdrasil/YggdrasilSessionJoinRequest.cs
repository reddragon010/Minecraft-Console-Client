using System;
using Newtonsoft.Json;

namespace MojangApi
{
	public class YggdrasilSessionJoinRequest
	{
		[JsonProperty("accessToken")]
		public string AccessToken {
			get;
			private set;
		}

		[JsonProperty("selectedProfile")]
		public string ProfileId {
			get;
			private set;
		}

		[JsonProperty("serverId")]
		public string ServerId {
			get;
			private set;
		}

		public YggdrasilSessionJoinRequest (string accessToken, string profileId, string serverId)
		{
			AccessToken = accessToken;
			ProfileId = profileId;
			ServerId = serverId;
		}
	}
}

