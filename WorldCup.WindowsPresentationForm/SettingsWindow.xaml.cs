using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldCup.BussinesLayer.Models;
using WorldCup.BussinesLayer.Repository;
using WorldCup.BussinesLayer.ViewModels;

namespace WorldCup.WindowsPresentationForm
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private List<LanguageVM> languageDataSource;
        private List<CupVM> cupsDataSource;
        private ISettingsRepository settingsRepo;
        private SettingsModel settings;

        public Window1()
        {
            InitializeComponent();
        }

        private void Window1_Load(object sender, EventArgs e)
        {

            this.settingsRepo = RepositoryFactory.GetSettingsRepository();
            if (settingsRepo == null)
            {
                System.Windows.MessageBox.Show("Pogreška", "Pogreška", MessageBoxButton.OK);
            }

            this.PrepareLanguages();
            this.PopulateLanguagesDataSource();

            this.PrepareCups();
            this.PopulateCupsDataSource();

            this.PopulateSettingsFromDatabase();
        }


        private void PopulateCupsDataSource()
        {
            cbGenderSelection.ItemsSource = this.cupsDataSource;
     
        }

        private void PopulateLanguagesDataSource()
        {
            cbLanguage.ItemsSource = this.languageDataSource;
         
        }


        private void PrepareLanguages()
        {
            this.languageDataSource = new List<LanguageVM>()
            {
                new LanguageVM()
                {
                    Name = Properties.Resources.language_croatian,
                    Value = "hr"
                },
                new LanguageVM()
                {
                    Name = Properties.Resources.language_english,
                    Value = "en"
                }
            };
        }

        private void PrepareCups()
        {
            this.cupsDataSource = new List<CupVM>()
            {
                new CupVM()
                {
                    Name = Properties.Resources.cup_male
                },
                new CupVM()
                {
                    Name = Properties.Resources.cup_female
                }
            };
        }

        // učitaj settings ako postoji 
        private void PopulateSettingsFromDatabase()
        {
            var getSettingsResponse = this.settingsRepo.GetSettingsTask(); //dohvati iz repoa trenutne postavke koje su spremljene u datoteci

            if (!getSettingsResponse.Succeded)
            {
                this.settings = new SettingsModel(); //ako nema ništa spremljeno stvori prazan settings model na razini ove klase/forme
                return;
            }
            this.settings = getSettingsResponse.Settings;
            var selectedLanguage = this.languageDataSource.Where(x => x.Value == this.settings.Language.Value).FirstOrDefault();
            // ako nešto ima spremljeno podesi tako jezik i cup
            if (selectedLanguage != null)
            {
                cbLanguage.SelectedItem = selectedLanguage;
            }

            var selectedCup = this.cupsDataSource.Where(x => x.Name == this.settings.Cup.Name).FirstOrDefault();

            if (selectedCup != null)
            {
                cbGenderSelection.SelectedItem = selectedCup;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var choosenLanguage = cbLanguage.SelectedItem as LanguageVM;
            var choosenCup = cbGenderSelection.SelectedItem as CupVM;

            if (choosenLanguage == null || choosenCup == null)
            {
                System.Windows.MessageBox.Show("Popunite sve podatke", "Validacija", MessageBoxButton.OK);
                return;
            }

            this.settings.Cup = choosenCup;
            this.settings.Language = choosenLanguage;

            this.settingsRepo.SaveSettingsTask(new SaveSettingsTaskRequest()
            {
                Settings = this.settings
            });

            //Promjeni jezik threada...
            var cultureInfo = new CultureInfo(choosenLanguage.Value);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;

            System.Windows.MessageBox.Show("Postavke uspješno spremljene", "Spremljeno", MessageBoxButton.OK);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.CanClose())
            {
                this.Close();
            }
        }

        private bool CanClose()
        {
            if (this.settings == null || this.settings.Language == null || this.settings.Cup == null)
            {
                System.Windows.MessageBox.Show("Molimo popunite postavke", "Ne može van", MessageBoxButton.OK);
                return false;
            }
            return true;
        }
      

        private void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!this.CanClose())
            {
                e.Cancel = true;
            }
        }
    }
}
