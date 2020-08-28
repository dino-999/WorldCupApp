using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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

		GetPlayerStatisticsForPlayerAndCupResponse GetPlayerStatisticsForPlayerAndCupTask(GetPlayerStatisticsForPlayerAndCupRequest request);

		GetMatchStatisticsForTeamAndCupResponse GetMatchStatisticsForTeamAndCupTask(GetMatchStatisticsForTeamAndCupRequest request);
	}

	public class GetMatchStatisticsForTeamAndCupResponse
	{
		public List<MatchRangListVM> Matches { get; set; }
	}

	public class GetMatchStatisticsForTeamAndCupRequest
	{
		public CupVM Cup { get; set; }

		public string TeamFifaCode { get; set; }
	}

	public class GetPlayerStatisticsForPlayerAndCupResponse
	{
		public List<PlayerRangListVM> Players { get; set; }
	}

	public class GetPlayerStatisticsForPlayerAndCupRequest
	{
		public CupVM Cup { get; set; }

		public string TeamFifaCode { get; set; }
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

		public GetPlayerStatisticsForPlayerAndCupResponse GetPlayerStatisticsForPlayerAndCupTask(GetPlayerStatisticsForPlayerAndCupRequest request)
		{
			var result = new GetPlayerStatisticsForPlayerAndCupResponse() { Players = new List<PlayerRangListVM>() };

			//Izvuci sve odigrane utakmice za tu reprezentaciju
			var matchRepository = RepositoryFactory.GetMatchRepository();

			var allMatchesResponse = matchRepository.GetAllMatchesTask(new GetAllMatchesRequest()
			{
				Cup = request.Cup,


			});

			var allMatchesForTeam = allMatchesResponse.Matches.Where(x => x.HomeTeam.Code == request.TeamFifaCode || x.AwayTeam.Code == request.TeamFifaCode).ToList();


			// iz prve odiigrane  utakmice izvuč playere




			foreach (var match in allMatchesForTeam)
			{
				if (match.HomeTeam.Code == request.TeamFifaCode)
				{
					foreach (var matchPlayer in match.HomeTeamStatistics.StartingEleven)
					{
						if (!IsPlayerExist(result.Players, matchPlayer))
						{
							result.Players.Add(new PlayerRangListVM()
							{
								Name = matchPlayer.Name,
							});
						}



					}

					foreach (var matchPlayer in match.HomeTeamStatistics.Substitutes)
					{
						if (!IsPlayerExist(result.Players, matchPlayer))
						{
							result.Players.Add(new PlayerRangListVM()
							{
								Name = matchPlayer.Name,
							});
						}


					}

				}

				if (match.AwayTeam.Code == request.TeamFifaCode)
				{
					foreach (var matchPlayer in match.AwayTeamStatistics.StartingEleven)
					{
						if (!IsPlayerExist(result.Players, matchPlayer))
						{
							result.Players.Add(new PlayerRangListVM()
							{
								Name = matchPlayer.Name,
							});
						}
					}

					foreach (var matchPlayer in match.AwayTeamStatistics.Substitutes)
					{
						if (!IsPlayerExist(result.Players, matchPlayer))
						{
							result.Players.Add(new PlayerRangListVM()
							{
								Name = matchPlayer.Name,
							});
						}


					}
				}


			}




			//Iračunaj žute kartone za igrača

			foreach (var player in result.Players)
			{
				int yellowCardCounter = 0;
				int matchesPlayedCounter = 0;
				int scoredGoalsCounter = 0;
				foreach (var match in allMatchesForTeam)
				{
					// provjeri je li igro
					if (match.HomeTeam.Code == request.TeamFifaCode)
					{
						if (match.HomeTeamStatistics.StartingEleven.Where(x => x.Name == player.Name).Any())
						{
							matchesPlayedCounter++;
						}
						else if (match.HomeTeamEvents.Where(x => x.TypeOfEvent == "substitution-in" && x.Player == player.Name).Any())
						{
							matchesPlayedCounter++;
						}

						// ako je koliko žutih ako uopce

						if (match.HomeTeamEvents.Where(x => x.TypeOfEvent == "yellow-card" && x.Player == player.Name).Any())
						{
							yellowCardCounter++;
						}


						if (match.HomeTeamEvents.Where(x => x.TypeOfEvent == "goal" && x.Player == player.Name).Any())
						{
							scoredGoalsCounter++;
						}

					}

					else
					{
						if (match.AwayTeamStatistics.StartingEleven.Where(x => x.Name == player.Name).Any())
						{
							matchesPlayedCounter++;
						}
						else if (match.AwayTeamEvents.Where(x => x.TypeOfEvent == "substitution-in" && x.Player == player.Name).Any())
						{
							matchesPlayedCounter++;
						}

						// ako je koliko žutih ako uopce

						if (match.AwayTeamEvents.Where(x => x.TypeOfEvent == "yellow-card" && x.Player == player.Name).Any())
						{
							yellowCardCounter++;
						}

						if (match.AwayTeamEvents.Where(x => x.TypeOfEvent == "goal" && x.Player == player.Name).Any())
						{
							scoredGoalsCounter++;
						}


					}




				}

				player.YellowCards = yellowCardCounter;
				player.ScoredGoals = scoredGoalsCounter;
				player.NumberOfGamesPlayed = matchesPlayedCounter;

				player.ImageFilePath = this.GetPictureForPlayerTask(new GetPictureForPlayerRequest()
				{
						Cup=request.Cup,
						PlayerName=player.Name,
						TeamFifaCode=request.TeamFifaCode

				}).ImagePath;



			}

			//Izračanuj broj odigranih utakmica


			return result;






		}

		private bool IsPlayerExist(List<PlayerRangListVM> players, Player matchPlayer)
		{


			return players.Any(x => x.Name == matchPlayer.Name);



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

		public GetMatchStatisticsForTeamAndCupResponse GetMatchStatisticsForTeamAndCupTask(GetMatchStatisticsForTeamAndCupRequest request)
		{
			var result = new GetMatchStatisticsForTeamAndCupResponse() { Matches = new List<MatchRangListVM>() };


			var matchRepository = RepositoryFactory.GetMatchRepository();

			var allMatchesResponse = matchRepository.GetAllMatchesTask(new GetAllMatchesRequest()
			{
				Cup = request.Cup,
				


			});

			var allMatchesForTeam = allMatchesResponse.Matches.Where(x => x.HomeTeam.Code == request.TeamFifaCode || x.AwayTeam.Code == request.TeamFifaCode).ToList();
			// Dohvati broj posjetitelja za određenu utakmicu


			foreach (var match in allMatchesForTeam)
			{

				result.Matches.Add(new MatchRangListVM()
				{
					AwayTeam = match.AwayTeamStatistics.Country,
					HomeTeam = match.HomeTeamStatistics.Country,
					Location = match.Location,
					NumberOfWatchers = match.Attendance
				});


			}

			//


			return result;
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
