using System;

namespace MojangApi
{
	public class MinecraftProfile
	{
		public string Id { get; private set; }

		public string Name { get; private set; }

		public MinecraftProfile(string id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}

