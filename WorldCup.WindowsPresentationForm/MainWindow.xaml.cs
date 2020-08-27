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
        public MainWindow()
        {
            InitializeComponent();
        }



        private void btnInfoEnemy_Click(object sender, RoutedEventArgs e)
        {
            Information info = new Information();
            this.Visibility = Visibility.Visible;
            info.Show();
        }

        private void btnInfoFavourite_Click(object sender, RoutedEventArgs e)
        {
            Information info = new Information();
            this.Visibility = Visibility.Visible;
            info.Show();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
           Settings settings = new Settings();
            this.Visibility = Visibility.Visible;
           
           PopulateSettingsFromDatabase();
           PopulateTeamsDropdown();
        }

        private void PopulateTeamsDropdown()
        {
            var getTeamTaskRequest = new GetTeamsTaskRequest()
            {
                Cup = settings.Cup
            };

            var allTeams = teamsRepo.GetTeamsTask(getTeamTaskRequest)?.Teams;

            //cbFavouriteTeam.DataSource = allTeams;
            //cbFavouriteTeam.ValueMember = "FifaCode";
            //cbFavouriteTeam.DisplayMember = "Country";

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
    }
}
