using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WorldCup.BussinesLayer
{
	public class PathsConstants
	{
		public static string DatabaseDirectoryPath { get; } = "..\\..\\..\\Db";
		public static string SettingsFilePath { get; } = "..\\..\\..\\Db\\settings_db.json";
		public static string FavouriteTeamSettingsFilePath { get; } = "..\\..\\..\\Db\\favouriteTeamSettings_db.json";
		public static string FavouritePlayerSettingsFilePath { get; } = "..\\..\\..\\Db\\favouritePlayerSetting_db.json";

		public static string PlayerImagesDirectory { get; } = "..\\..\\..\\Db\\playerImages";


	}

	public static class FileUtils
	{
		public static void EnsureDb()
		{
			if (!Directory.Exists(PathsConstants.DatabaseDirectoryPath))
			{
				Directory.CreateDirectory(PathsConstants.DatabaseDirectoryPath);
			}

			if (!Directory.Exists(PathsConstants.PlayerImagesDirectory))
			{
				Directory.CreateDirectory(PathsConstants.PlayerImagesDirectory);
			}

			if (!File.Exists(PathsConstants.SettingsFilePath))
			{
				File.Create(PathsConstants.SettingsFilePath);
				File.WriteAllText(PathsConstants.SettingsFilePath, "{}");
			}

			if (!File.Exists(PathsConstants.FavouriteTeamSettingsFilePath))
			{
				File.Create(PathsConstants.FavouriteTeamSettingsFilePath);
				File.WriteAllText(PathsConstants.FavouriteTeamSettingsFilePath, "{}");
			}

			if (!File.Exists(PathsConstants.FavouritePlayerSettingsFilePath))
			{
				File.Create(PathsConstants.FavouritePlayerSettingsFilePath);
				File.WriteAllText(PathsConstants.FavouritePlayerSettingsFilePath, "{}");
			}
		}
	}
}
