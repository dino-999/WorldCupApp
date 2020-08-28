﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WorldCup.BussinesLayer.Models;
using WorldCup.BussinesLayer.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace WorldCup.BussinesLayer.Repository
{
	public interface IPLayerRepository
	{
		GetFavouritePlayersForTeamAndCupTaskResponse GetFavouritePlayersForTeamAndCupTask(GetFavouritePlayersForTeamAndCupTaskRequest request);
		AddFavouritePlayerForTeamAndCupTaskResponse AddFavouritePlayerForTeamAndCupTask(AddFavouritePlayerForTeamAndCupTaskRequest request);
		RemoveFavouritePlayerForTeamAndCupTaskResponse RemoveFavouritePlayerForTeamAndCupTask(RemoveFavouritePlayerForTeamAndCupTaskRequest request);

		GetPictureForPlayerResponse GetPictureForPlayerTask(GetPictureForPlayerRequest request);

		SavePictureForPlayerResponse SavePictureForPlayerTask(SavePictureForPlayerRequest request);
	}
	public class FilePlayerRepository : IPLayerRepository
	{
		public AddFavouritePlayerForTeamAndCupTaskResponse AddFavouritePlayerForTeamAndCupTask(AddFavouritePlayerForTeamAndCupTaskRequest request)
		{
			var settings = this.GetFavouritePlayers();
			using (StreamWriter sw = new StreamWriter(PathsConstants.FavouritePlayerSettingsFilePath))
			{
				CupTeamPlayerWrapper cupTeamPlayerWrapper = new CupTeamPlayerWrapper()
				{
					Cup = request.Cup,
					Player = request.Player,
					TeamFifaCode = request.TeamFifaCode
				};


				//TODO: Provjera postoji li već

				settings.Players.Add(cupTeamPlayerWrapper);

				var json = JsonConvert.SerializeObject(settings);
				sw.Write(json);
			}

			return new AddFavouritePlayerForTeamAndCupTaskResponse();
		}

		public GetFavouritePlayersForTeamAndCupTaskResponse GetFavouritePlayersForTeamAndCupTask(GetFavouritePlayersForTeamAndCupTaskRequest request)
		{
			FavouritePlayersSettingsModel favouritePlayersSettingsModel = this.GetFavouritePlayers();  //Convert from json

			var players = favouritePlayersSettingsModel.Players
				.Where(x => x.Cup.Name == request.Cup.Name && x.TeamFifaCode == request.TeamFifaCode)
				.Select(x => x.Player)
				.ToList();

			return new GetFavouritePlayersForTeamAndCupTaskResponse()//Objekt upakiraj u response i vrati ga nazad
			{
				Players = players
			};
		}

		public GetPictureForPlayerResponse GetPictureForPlayerTask(GetPictureForPlayerRequest request)
		{
			string imageFolderPath = Path.Combine(PathsConstants.PlayerImagesDirectory, $"{request.Cup.Name}_{request.TeamFifaCode}_{request.PlayerName}.jpeg");

			var result = new GetPictureForPlayerResponse();
			if (File.Exists(imageFolderPath))
			{
				result.ImagePath = imageFolderPath;

			}
			else
			{
				//DefaultJsonNameTable slika

				string defaultImageFolderPath = Path.Combine(PathsConstants.PlayerImagesDirectory, $"default.png");

				result.ImagePath = defaultImageFolderPath;
			}

			return result;

		}

		public RemoveFavouritePlayerForTeamAndCupTaskResponse RemoveFavouritePlayerForTeamAndCupTask(RemoveFavouritePlayerForTeamAndCupTaskRequest request)
		{
			var settings = this.GetFavouritePlayers();
			if (!settings.Players.Any())
			{
				return new RemoveFavouritePlayerForTeamAndCupTaskResponse();
			}

			using (StreamWriter sw = new StreamWriter(PathsConstants.FavouritePlayerSettingsFilePath))
			{

				var playerToRemove = settings.Players
					.Where(x => x.Cup.Name == request.Cup.Name && x.TeamFifaCode == request.TeamFifaCode && x.Player.Name == request.Player.Name)
					.ToList();

				settings.Players = settings.Players.Except(playerToRemove).ToList();

				var json = JsonConvert.SerializeObject(settings);
				sw.Write(json);
			}

			return new RemoveFavouritePlayerForTeamAndCupTaskResponse();
		}

		public SavePictureForPlayerResponse SavePictureForPlayerTask(SavePictureForPlayerRequest request)
		{
			string imageFolderPath = Path.Combine(PathsConstants.PlayerImagesDirectory, $"{request.Cup.Name}_{request.TeamFifaCode}_{request.PlayerName}.jpeg");


			File.WriteAllBytes(imageFolderPath, request.Image);

			return new SavePictureForPlayerResponse();


		}
		private FavouritePlayersSettingsModel GetFavouritePlayers()
		{
			if (!File.Exists(PathsConstants.FavouritePlayerSettingsFilePath))
			{
				File.Create(PathsConstants.FavouritePlayerSettingsFilePath).Dispose();
			}
			using (StreamReader sr = new StreamReader(PathsConstants.FavouritePlayerSettingsFilePath))
			{


				var json = sr.ReadToEnd();  // Pročitaj string iz file-a

				if (string.IsNullOrEmpty(json))
				{
					return new FavouritePlayersSettingsModel()
					{
						Players = new List<CupTeamPlayerWrapper>()
					};
				}


				FavouritePlayersSettingsModel favouritePlayersSettingsModel = JsonConvert.DeserializeObject<FavouritePlayersSettingsModel>(json);   //Convert from json


				return favouritePlayersSettingsModel;

			}
		}


	}

	public class SavePictureForPlayerResponse
	{
		public bool Success { get; set; } = true;
	}

	public class SavePictureForPlayerRequest
	{
		public byte[] Image { get; set; }
		public string PlayerName { get; set; }
		public CupVM Cup { get; set; }
		public string TeamFifaCode { get; set; }
	}

	public class GetPictureForPlayerResponse
	{
		public string ImagePath { get; internal set; }
	}

	public class GetPictureForPlayerRequest
	{
		public string PlayerName { get; set; }
		public CupVM Cup { get; set; }
		public string TeamFifaCode { get; set; }
	}

	public class GetFavouritePlayersForTeamAndCupTaskRequest
	{
		public CupVM Cup { get; set; }
		public string TeamFifaCode { get; set; }
	}

	public class GetFavouritePlayersForTeamAndCupTaskResponse
	{
		public List<Player> Players { get; set; }
	}
	public class RemoveFavouritePlayerForTeamAndCupTaskResponse
	{
		public bool Success { get; set; } = true;
	}

	public class RemoveFavouritePlayerForTeamAndCupTaskRequest
	{
		public Player Player { get; set; }
		public CupVM Cup { get; set; }
		public string TeamFifaCode { get; set; }
	}

	public class AddFavouritePlayerForTeamAndCupTaskResponse
	{
		public bool Success { get; set; } = true;
	}

	public class AddFavouritePlayerForTeamAndCupTaskRequest
	{
		public Player Player { get; set; }
		public CupVM Cup { get; set; }
		public string TeamFifaCode { get; set; }
	}

}
