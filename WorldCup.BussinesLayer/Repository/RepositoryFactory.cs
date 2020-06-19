﻿using System;
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
	}
}
