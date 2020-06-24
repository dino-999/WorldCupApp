using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace WorldCup.BussinesLayer.Repository
{
	public static class RepositoryFactory
	{
		public static ISettingsRepository GetSettingsRepository()
		{
			return new FileSettingsRepository();
		}

		public static IPlayerRepository GetPlayerRepository()
        {
			return new FilePlayerRepository();
        }
		public static ITeamsRepository GetTeamsRepository()
        {
			return new FileTeamsRepository();
		}


	}
}
