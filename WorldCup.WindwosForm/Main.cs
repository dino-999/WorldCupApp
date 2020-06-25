using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.BussinesLayer.Models;
using WorldCup.BussinesLayer.Repository;
using WorldCup.BussinesLayer.ViewModels;

namespace WorldCup.WindwosForm
{

    public partial class Main : Form
    {
        private ISettingsRepository settingsRepo;
        private SettingsModel settings;
        private ITeamsRepository teamsRepo;


        public Main()
        {
            InitializeComponent();
            this.settingsRepo = RepositoryFactory.GetSettingsRepository();
            this.teamsRepo = RepositoryFactory.GetTeamsRepository();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //dohvati treuntne postavke




            PopulateSettingsFromDatabase();

            //provjeriti jeli pohranjeno jezik i cup 
            if (settings.Cup == null || settings.Language == null)
            {
                //ako nije digni setting kao modalnu formu--> naloadaj timove kao dropdown i oznaci omiljeni
                Settings s = new Settings();
                s.ShowDialog(this);
                PopulateSettingsFromDatabase();
            }

            //ako je naloadaj timove kao dropdown i oznaci omiljeni

            PopulateTeamsDropdown();

        }

        private void PopulateTeamsDropdown()
        {
            var getTeamTaskRequest = new GetTeamsTaskRequest()
            {
                Cup = settings.Cup
            };

            var allTeams = teamsRepo.GetTeamsTask(getTeamTaskRequest)?.Teams;

            cbFavouriteTeam.DataSource = allTeams;
            cbFavouriteTeam.ValueMember = "FifaCode";
            cbFavouriteTeam.DisplayMember = "Country";

            var favouriteTeam = this.teamsRepo.GetFavouriteTeamTask(new GetFavouriteTeamTaskRequest()
            {
                Cup = this.settings.Cup
            });

            if(favouriteTeam.Team != null)
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.ShowDialog(this);
            PopulateSettingsFromDatabase();
            PopulateTeamsDropdown();
        }

        private void btnMakeFavourite_Click(object sender, EventArgs e)
        {
            var currentSelectedTeam = (TeamVM)cbFavouriteTeam.SelectedItem;
            var saveFavouriteTeamTaskResponse = teamsRepo.SaveFavouriteTeamsTask(new SaveFavouriteTeamTaskRequest()
            {
                Cup = settings.Cup,
                Team = currentSelectedTeam
            });

            if (saveFavouriteTeamTaskResponse.Suceeded)
            {
                MessageBox.Show("Uspješno spremljeno!");
            }
            else
            {
                MessageBox.Show("Nije uspješno spremljeno!");
            }

        }
    }
}
