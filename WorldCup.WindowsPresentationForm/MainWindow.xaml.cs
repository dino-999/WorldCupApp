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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorldCup.BussinesLayer.Models;
using WorldCup.BussinesLayer.Repository;
using WorldCup.BussinesLayer.ViewModels;
using WorldCup.WindowsPresentationForm.Properties;

namespace WorldCup.WindowsPresentationForm
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ISettingsRepository settingsRepo;
		private SettingsModel settings;
		private ITeamsRepository teamsRepo;
		private IMatchRepository matchRepo;
		public MainWindow()
		{
			InitializeComponent();
			this.settingsRepo = RepositoryFactory.GetSettingsRepository();
			this.teamsRepo = RepositoryFactory.GetTeamsRepository();
			this.matchRepo = RepositoryFactory.GetMatchRepository();
		}



		private void btnInfoEnemy_Click(object sender, RoutedEventArgs e)
		{

			var selectedTeam = cbEnemyTeam.SelectedItem as TeamVM;
			if (selectedTeam==null)
			{
				return;
			}
			Information info = new Information(new TeamInformationVM()
			{
				Name = selectedTeam.Country,
				Difference=selectedTeam.GoalDifferential,
				Wins=selectedTeam.Wins,
				Loses=selectedTeam.Losses,
				Draws=selectedTeam.Draws,
				ScoredGoals=selectedTeam.GoalsAgainst,
				GottenGoals=selectedTeam.GoalsFor,
				FifaCode=selectedTeam.FifaCode,
				GamesPlayed=selectedTeam.GamesPlayed
			});

			this.Visibility = Visibility.Visible;
			info.Show();
		}

		private void btnInfoFavourite_Click(object sender, RoutedEventArgs e)
		{

			var selectedTeam = cbFavouriteTeam.SelectedItem as TeamVM;
			if (selectedTeam == null)
			{
				return;
			}
			Information info = new Information(new TeamInformationVM()
			{
				Name = selectedTeam.Country,
				Difference = selectedTeam.GoalDifferential,
				Wins = selectedTeam.Wins,
				Loses = selectedTeam.Losses,
				Draws = selectedTeam.Draws,
				ScoredGoals = selectedTeam.GoalsAgainst,
				GottenGoals = selectedTeam.GoalsFor,
				FifaCode = selectedTeam.FifaCode,
				GamesPlayed = selectedTeam.GamesPlayed
			});

			this.Visibility = Visibility.Visible;
			info.Show();
		}

		private void btnSettings_Click(object sender, RoutedEventArgs e)
		{
			Window1 s=new Window1();
			this.Visibility = Visibility.Visible;

			
			PopulateSettingsFromDatabase();
			PopulateTeamsDropdown();

			s.Show();
			

		}

		private void PopulateTeamsDropdown()
		{
			var getTeamTaskRequest = new GetTeamsTaskRequest()
			{
				Cup = settings.Cup
			};

			var allTeams = teamsRepo.GetTeamsTask(getTeamTaskRequest)?.Teams;

			cbFavouriteTeam.ItemsSource = allTeams;
			
			cbEnemyTeam.ItemsSource=allTeams;
			

			var favouriteTeam = this.teamsRepo.GetFavouriteTeamTask(new GetFavouriteTeamTaskRequest()
			{
				Cup = this.settings.Cup
			});

			if (favouriteTeam.Team != null)
			{
				var favouriteTeamFromDataSource = allTeams.Where(x => x.FifaCode == favouriteTeam.Team.FifaCode).FirstOrDefault();
				cbFavouriteTeam.SelectedItem = favouriteTeamFromDataSource;
			}
		}

		private void PopulateSettingsFromDatabase()
		{
			var getSettingsResponse = this.settingsRepo.GetSettingsTask(); //dohvati iz repoa trenutne postavke koje su spremljene u datoteci

			if (!getSettingsResponse.Succeded)
			{
				this.settings = new SettingsModel(); //ako nema ništa spremljeno stvori prazan settings model na razini ove klase/forme
				return;
			}
			this.settings = getSettingsResponse.Settings;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			PopulateSettingsFromDatabase();
			PopulateTeamsDropdown();
		}

		private void Main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (MessageBox.Show("Jeste li sigurni?") != MessageBoxResult.OK)
			{
				e.Cancel = true;
			}
		}
	}
}
