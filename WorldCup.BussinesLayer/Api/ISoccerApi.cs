﻿using RestEase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldCup.BussinesLayer.Models;

namespace WorldCup.BussinesLayer.Api
{
    public interface ISoccerApi
    {
        [Get("matches")]
        Task<List<MatchDetail>> GetMatchDetails();

        [Get("teams/results")]
        Task<List<Team>> GetTeams();
    }
}
