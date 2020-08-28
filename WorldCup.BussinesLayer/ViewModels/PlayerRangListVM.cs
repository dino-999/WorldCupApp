using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCup.BussinesLayer.ViewModels
{
	public class PlayerRangListVM
	{
		public string Name { get; set; }
		public int YellowCards { get; set; }

		public int ScoredGoals { get; set; }

		public string ImageFilePath { get; set; }
		public int NumberOfGamesPlayed { get; set; }
	}
}
