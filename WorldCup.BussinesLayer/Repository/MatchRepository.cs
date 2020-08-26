using Newtonsoft.Json;
using RestEase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using WorldCup.BussinesLayer.Api;
using WorldCup.BussinesLayer.Models;
using WorldCup.BussinesLayer.ViewModels;

namespace WorldCup.BussinesLayer.Repository
{
    public interface IMatchRepository
    {
        GetAllMatchesTaskResponse GetAllMatchesTask(GetAllMatchesRequest request);

        GetAllPlayersForTeamTaskResponse GetAllPlayersForTeamTask(GetAllPlayersForTeamTaskRequest request);
        
    }

    public class GetAllPlayersForTeamTaskRequest
    {
        public string FifaCode { get; set; }
        public CupVM Cup { get; set; }
    }

    public class GetAllPlayersForTeamTaskResponse
    {
        public List<Player> Players { get; set; }
    }

    public class MatchRepository : IMatchRepository
    {
        public GetAllMatchesTaskResponse GetAllMatchesTask(GetAllMatchesRequest request)
        {
            var result = new GetAllMatchesTaskResponse();

            if(request.Cup.Name == CupVM.MaleCup)
            {
                var api = RestClient.For<ISoccerApi>("https://world-cup-json-2018.herokuapp.com/");
                result.Matches = api.GetMatchDetails().GetAwaiter().GetResult();
            }
            else if(request.Cup.Name == CupVM.FemaleCup)
            {
                var api = RestClient.For<ISoccerApi>("https://worldcup.sfg.io/");
                result.Matches = api.GetMatchDetails().GetAwaiter().GetResult();                
            }

            return result;
        }

        public GetAllPlayersForTeamTaskResponse GetAllPlayersForTeamTask(GetAllPlayersForTeamTaskRequest request)
        {
            var response = new GetAllPlayersForTeamTaskResponse()
            {
                Players = new List<Player>()
            };

            var allMatches = this.GetAllMatchesTask(new GetAllMatchesRequest()
            {
                Cup = request.Cup
            });

            var match = allMatches.Matches
                .Where(x => x.HomeTeam.Code == request.FifaCode || x.AwayTeam.Code == request.FifaCode)
                .FirstOrDefault();

            if (match == null)
            {
                return response;
            }

            if (match.AwayTeam.Code == request.FifaCode)
            {
                response.Players.AddRange(match.AwayTeamStatistics.StartingEleven);
                response.Players.AddRange(match.AwayTeamStatistics.Substitutes);
            }
            else if (match.HomeTeam.Code == request.FifaCode)
            {
                response.Players.AddRange(match.HomeTeamStatistics.StartingEleven);
                response.Players.AddRange(match.HomeTeamStatistics.Substitutes);
            }

            return response;
        }
    }
    public class GetAllMatchesRequest
    {
        public CupVM Cup { get; set; }
    }

    public class GetAllMatchesTaskResponse
    {
        public List<MatchDetail> Matches { get; set; }
    }

}
