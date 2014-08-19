using System;
using System.Collections.Generic;

namespace MojangApi
{
	public class MinecraftUser
	{
		public ICollection<MinecraftProfile> Profiles { get; set; }
		public MinecraftProfile SelectedProfile { get; set; }

		public string Username { get; private set; }

		public string AuthToken { get; set; }
		public string Password { get; private set; }

		public MinecraftUser (string username, string password)
		{
			Username = username;
			Password = password;
		}

		public MinecraftUser (string authToken)
		{
			AuthToken = authToken;
		}
	}
}

