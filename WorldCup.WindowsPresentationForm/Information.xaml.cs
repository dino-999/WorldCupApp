using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldCup.BussinesLayer.ViewModels;

namespace WorldCup.WindowsPresentationForm
{
	/// <summary>
	/// Interaction logic for Information.xaml
	/// </summary>
	public partial class Information : Window
	{
		private readonly TeamInformationVM team;

		public Information(TeamInformationVM team)
		{
			InitializeComponent();
			this.team = team;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			tbName.Text = this.team.Name;
			tbFifaCode.Text = this.team.FifaCode;
			tbGamesPlayed.Text = this.team.GamesPlayed.ToString();
			tbWins.Text = this.team.Wins.ToString();
			tbLoses.Text = this.team.Loses.ToString(); 
			tbDraws.Text = this.team.Draws.ToString();
			tbScoredGoals.Text = this.team.ScoredGoals.ToString();
			tbGottenGoals.Text = this.team.GottenGoals.ToString();
			tbDifference.Text = this.team.Difference.ToString();
			
		}
	}
}
