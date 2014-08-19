using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace MojangApi
{
	public class YggdrasilAuthProvider : YggdrasilHttpClient, IMinecraftAuthProvider
	{
		public YggdrasilAuthProvider ()
		{}

		public YggdrasilAuthProvider (WebClient webClient) 
			: base(webClient) 
		{}

		#region IMinecraftAuthProvider implementation
		public MinecraftLoginResult Login (MinecraftUser user)
		{
			MinecraftLoginResult result;
			if (!string.IsNullOrWhiteSpace (user.Username) && !string.IsNullOrWhiteSpace (user.Password))
				result = LoginUsingUsernameAndPassword (user);
			else if (!string.IsNullOrWhiteSpace (user.AuthToken))
				result = LoginUseingTokens (user);
			else
				throw new InvalidOperationException ("Can't Login without an given Username/Password- or AccessToken/ClientToken-combination");

			if (result == MinecraftLoginResult.Success && user.Profiles.Count <= 0)
					result = MinecraftLoginResult.NotPremium;

			return result;
		}

		//TODO: Implement Logout
		public void Logout (MinecraftUser user)
		{
			throw new NotImplementedException ();
		}
		#endregion

		private MinecraftLoginResult LoginUsingUsernameAndPassword(MinecraftUser user)
		{
			YggdrasilAuthRequest request = new YggdrasilAuthRequest(user.Username, user.Password, GetClientToken());
			YggdrasilAuthResponse response = SubmitRequest<YggdrasilAuthResponse, YggdrasilAuthRequest>(Yggdrasil.AUTH_LOGIN_URL, request);

			user.AuthToken = response.AccessToken;
			user.Profiles = response.AvailableProfiles.Select(p => new MinecraftProfile (p.Id, p.Name)).ToList();
			user.SelectedProfile = user.Profiles.First (p => p.Id == response.SelectedProfile.Id);

			return MinecraftLoginResult.Success;
		}

		private MinecraftLoginResult LoginUseingTokens(MinecraftUser user)
		{
			YggdrasilRefreshRequest request = new YggdrasilRefreshRequest(user.AuthToken, GetClientToken());
			YggdrasilRefreshResponse response = SubmitRequest<YggdrasilRefreshResponse, YggdrasilRefreshRequest>(Yggdrasil.AUTH_REFRESH_URL, request);

			user.AuthToken = response.AccessToken;
			user.SelectedProfile = new MinecraftProfile (response.SelectedProfile.Id, response.SelectedProfile.Name);
			user.Profiles = new List<MinecraftProfile>() { user.SelectedProfile };

			return MinecraftLoginResult.Success;
		}
	}
}

