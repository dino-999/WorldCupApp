using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.BussinesLayer.Models;
using WorldCup.BussinesLayer.Repository;
using WorldCup.BussinesLayer.ViewModels;

namespace WorldCup.WindwosForm
{
	public partial class Settings : Form
	{
		private List<LanguageVM> languageDataSource;
		private List<CupVM> cupsDataSource;
		private ISettingsRepository settingsRepo;
		private SettingsModel settings;

		public Settings()
		{
			InitializeComponent();
		}

		private void Settings_Load(object sender, EventArgs e)
		{

			this.settingsRepo = RepositoryFactory.GetSettingsRepository();
			if (settingsRepo == null)
			{
				MessageBox.Show("Problemi...", "Sranje", MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}

			this.PrepareLanguages();
			this.PopulateLanguagesDataSource();

			this.PrepareCups();
			this.PopulateCupsDataSource();

			this.PopulateSettingsFromDatabase();
		}

		private void PopulateCupsDataSource()
		{
			cbGenderSelection.DataSource = this.cupsDataSource;
			cbGenderSelection.ValueMember = "Name";
			cbGenderSelection.DisplayMember = "Name";
		}

		private void PopulateLanguagesDataSource()
		{
			cbLanguage.DataSource = this.languageDataSource;
			cbLanguage.DisplayMember = "Name";
			cbLanguage.ValueMember = "Value";
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

		private void PopulateSettingsFromDatabase()
		{
			var getSettingsResponse = this.settingsRepo.GetSettingsTask();

			if(!getSettingsResponse.Succeded)
			{
				this.settings = new SettingsModel();
				return;
			}
			this.settings = getSettingsResponse.Settings;
			var selectedLanguage = this.languageDataSource.Where(x => x.Name == this.settings.Language.Name).FirstOrDefault();

			if(selectedLanguage != null)
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

			if(choosenLanguage == null || choosenCup == null)
			{
				MessageBox.Show("Popunite sve podatke","Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

			MessageBox.Show("Postavke uspješno spremljene", "Spremljeno", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				MessageBox.Show("Odjebi");
				return false;
			}
			return true;
		}
		private void Settings_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.CanClose())
			{
				e.Cancel = true;
			}			
		}
	}
}
