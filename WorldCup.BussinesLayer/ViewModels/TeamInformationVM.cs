using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCup.BussinesLayer.ViewModels
{
	public class TeamInformationVM
	{
		public string Name { get; set; }
		public string FifaCode{ get; set; }

		public int GamesPlayed { get; set; }
		public int Wins { get; set; }
		public int Loses { get; set; }

		public int Draws { get; set; }

		public int ScoredGoals { get; set; }
		public int GottenGoals { get; set; }

		public int Difference { get; set; }
	}
}
