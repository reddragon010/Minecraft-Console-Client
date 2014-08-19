using System;

namespace MojangApi
{
	public enum MinecraftLoginResult
	{
		OtherError, 
		ServiceUnavailable, 
		SSLError, 
		Success, 
		WrongPassword, 
		Blocked, 
		AccountMigrated, 
		NotPremium
	}
}

