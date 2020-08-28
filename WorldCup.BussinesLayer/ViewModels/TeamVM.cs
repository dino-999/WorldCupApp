using System;
using System.Collections.Generic;
using System.Text;
using WorldCup.BussinesLayer.Models;

namespace WorldCup.BussinesLayer.ViewModels
{
    public class TeamVM : Team
    {
        //Nothing do far...
        public TeamVM()
        {

        }
        public TeamVM(Team team)
        {
            this.Id= team.Id;
            this.Country = team.Country;
            this.AlternateName = team.AlternateName;
            this.FifaCode = team.FifaCode;
            this.GroupId = team.GroupId;
            this.GroupLetter = team.GroupLetter;
            this.Wins = team.Wins;
            this.Losses = team.Losses;
            this.Draws = team.Draws;
            this.GamesPlayed = team.GamesPlayed;
			this.Points = team.Points;
            this.GoalsFor = team.GoalsFor;
            this.GoalsAgainst = team.GoalsAgainst;
            this.GoalDifferential = team.GoalDifferential;
            
        }
    }
}
