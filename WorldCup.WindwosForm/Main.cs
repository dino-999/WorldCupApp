using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.BussinesLayer;
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
		private IMatchRepository matchRepo;
		private IPLayerRepository playerRepo;

		public int PrintedPages { get; set; }
		public int PagesToPrint { get; set; }

		public Main()
		{
			InitializeComponent();
			this.settingsRepo = RepositoryFactory.GetSettingsRepository();
			this.teamsRepo = RepositoryFactory.GetTeamsRepository();
			this.matchRepo = RepositoryFactory.GetMatchRepository();
			this.playerRepo = RepositoryFactory.GetPLayerRepository();
			PagesToPrint = 1;

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


			var favouriteTeam = this.teamsRepo.GetFavouriteTeamTask(new GetFavouriteTeamTaskRequest()
			{
				Cup = this.settings.Cup
			});

			if (favouriteTeam.Team != null)
			{
				var favouriteTeamFromDataSource = allTeams.Where(x => x.FifaCode == favouriteTeam.Team.FifaCode).FirstOrDefault();
				cbFavouriteTeam.SelectedItem = favouriteTeamFromDataSource;
			}

			cbFavouriteTeam.DisplayMember = "Country";
			cbFavouriteTeam.ValueMember = "FifaCode";
			cbFavouriteTeam.DataSource = allTeams;
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

		#region Print



		private void btnPrint_Click(object sender, EventArgs e)
		{
			int height = dgvShowPlayerInfo.Height;

			printPreviewDialog1.PrintPreviewControl.Zoom = 1;
			printPreviewDialog1.ShowDialog();
			printPreviewDialog1.Height = height;
			printDocument1.Print();

		}
		private void btnPrintRangList2_Click(object sender, EventArgs e)
		{
			int height = dgvShowMatchInfo.Height;

			printPreviewDialog2.PrintPreviewControl.Zoom = 1;
			printPreviewDialog2.ShowDialog();
			printPreviewDialog2.Height = height;
			printDocument2.Print();

		}
		private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
		{

			Bitmap bm = new Bitmap(this.dgvShowMatchInfo.Width, this.dgvShowMatchInfo.Height);
			dgvShowMatchInfo.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvShowMatchInfo.Width, this.dgvShowMatchInfo.Height));
			e.Graphics.DrawImage(bm, 0, 0);
		}
		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{

			Bitmap bm = new Bitmap(this.dgvShowPlayerInfo.Width, this.dgvShowPlayerInfo.Height);
			dgvShowPlayerInfo.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvShowPlayerInfo.Width, this.dgvShowPlayerInfo.Height));
			e.Graphics.DrawImage(bm, 0, 0);


		}


		#endregion

		private void ctrlTable1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.ctrlTable1.SelectedTab == this.tabPage1)
			{
				RefreshDataOnPlayersTab();
			}
			else if (this.ctrlTable1.SelectedTab == this.tabPage2)
			{
				RefreshRagListOne();
			}
			else if (this.ctrlTable1.SelectedTab == this.tabPage3)
			{
				RefreshRagListTwo();
			}
		}

		private void RefreshRagListTwo()
		{
			var teamFifaCode = this.cbFavouriteTeam.SelectedValue as string;

			var match = this.playerRepo.GetMatchStatisticsForTeamAndCupTask(new GetMatchStatisticsForTeamAndCupRequest()
			{
				Cup = this.settings.Cup,
				TeamFifaCode = teamFifaCode
			});


			var bindingList = new BindingList<MatchRangListVM>(match.Matches);
			var source = new BindingSource(bindingList, null);
			dgvShowMatchInfo.DataSource = source;
			dgvShowMatchInfo.AutoGenerateColumns = false;

		}


		private void RefreshRagListOne()
		{
			var teamFifaCode = this.cbFavouriteTeam.SelectedValue as string;

			var player = this.playerRepo.GetPlayerStatisticsForPlayerAndCupTask(new GetPlayerStatisticsForPlayerAndCupRequest()
			{
				Cup = this.settings.Cup,
				TeamFifaCode = teamFifaCode
			});


			var bindingList = new BindingList<PlayerRangListVM>(player.Players);
			var source = new BindingSource(bindingList, null);
			dgvShowPlayerInfo.DataSource = source;
			dgvShowPlayerInfo.AutoGenerateColumns = false;
			var imageCellGlobal = dgvShowPlayerInfo.Columns["ImageFilePath"] as DataGridViewImageColumn;
			imageCellGlobal.ImageLayout = DataGridViewImageCellLayout.Stretch;

			foreach (DataGridViewRow row in dgvShowPlayerInfo.Rows)
			{
				var imageCell = row.Cells["ImageFilePath"];
				if (imageCell != null)
				{


					var imagePath = (row.DataBoundItem as PlayerRangListVM).ImageFilePath;
					imageCell.Value = Image.FromFile(imagePath);
				}
			}
		}

		#region Player tab

		private void RefreshDataOnPlayersTab()
		{
			var teamFifaCode = this.cbFavouriteTeam.SelectedValue as string;

			var getAllPlayersForTeamResponse = this.matchRepo.GetAllPlayersForTeamTask(new GetAllPlayersForTeamTaskRequest()
			{
				Cup = this.settings.Cup,
				FifaCode = teamFifaCode
			});

			flpAllPlayers.Controls.Clear();
			flpFavourites.Controls.Clear();

			//Dohvati omiljene igrače za timecode i cup

			var getFavouritePlayers = this.playerRepo.GetFavouritePlayersForTeamAndCupTask(new GetFavouritePlayersForTeamAndCupTaskRequest()
			{
				Cup = this.settings.Cup,
				TeamFifaCode = teamFifaCode
			});

			foreach (var player in getAllPlayersForTeamResponse.Players)
			{
				var playerIsFavourite = false;
				//sadži li ta nova lista ovog playera koji je u foreachu
				foreach (var p in getFavouritePlayers.Players)
				{
					if (p.Name == player.Name && p.ShirtNumber == player.ShirtNumber)
					{
						playerIsFavourite = true;
						break;
					}
				}

				var getPictureForPlayerResponse = this.playerRepo.GetPictureForPlayerTask(new GetPictureForPlayerRequest()
				{
					Cup = this.settings.Cup,
					PlayerName = player.Name,
					TeamFifaCode = teamFifaCode
				});

				if (playerIsFavourite)
				{
					var RemoveFavouriteContextMenuItem = new ContextMenuStrip();
					RemoveFavouriteContextMenuItem.Items.Add("Makni iz favorita");
					RemoveFavouriteContextMenuItem.Items[0].Click += RemoveFavourite;
					RemoveFavouriteContextMenuItem.Items[0].Tag = player;

					RemoveFavouriteContextMenuItem.Items.Add("Učitaj sliku");
					RemoveFavouriteContextMenuItem.Items[1].Click += UploadPicture;
					RemoveFavouriteContextMenuItem.Items[1].Tag = player;



					flpFavourites.Controls.Add(new PlayerUC(new PlayerVM(player, playerIsFavourite, getPictureForPlayerResponse.ImagePath))
					{
						ContextMenuStrip = RemoveFavouriteContextMenuItem
					});

				}
				else
				{
					var AddFavouriteContextMenuItem = new ContextMenuStrip();
					AddFavouriteContextMenuItem.Items.Add("Dodaj u favorite");
					AddFavouriteContextMenuItem.Items[0].Click += AddFavourite;
					AddFavouriteContextMenuItem.Items[0].Tag = player;

					AddFavouriteContextMenuItem.Items.Add("Učitaj sliku");
					AddFavouriteContextMenuItem.Items[1].Click += UploadPicture;
					AddFavouriteContextMenuItem.Items[1].Tag = player;


					flpAllPlayers.Controls.Add(new PlayerUC(new PlayerVM(player, playerIsFavourite, getPictureForPlayerResponse.ImagePath))
					{
						ContextMenuStrip = AddFavouriteContextMenuItem
					});
				}
			}
		}

		private void UploadPicture(object sender, EventArgs e)
		{
			OpenFileDialog opf = new OpenFileDialog();

			if (opf.ShowDialog() == DialogResult.OK)
			{
				var Picture = File.ReadAllBytes(opf.FileName);

				var toolStripMenuItem = (ToolStripMenuItem)sender;
				var player = (Player)toolStripMenuItem.Tag;

				var teamFifaCode = this.cbFavouriteTeam.SelectedValue as string;

				var SavePictureResult = this.playerRepo.SavePictureForPlayerTask(new SavePictureForPlayerRequest()
				{
					Cup = this.settings.Cup,
					Image = Picture,
					PlayerName = player.Name,
					TeamFifaCode = teamFifaCode
				});
				if (!SavePictureResult.Success)
				{
					MessageBox.Show("Pokušajte ponovo");
				}
			}
			opf.Dispose();

		}

		private void RemoveFavourite(object sender, EventArgs e)
		{
			var toolStrimMenuItem = (ToolStripMenuItem)sender;
			var player = (Player)toolStrimMenuItem.Tag;

			var teamFifaCode = this.cbFavouriteTeam.SelectedValue as string;
			this.playerRepo.RemoveFavouritePlayerForTeamAndCupTask(new RemoveFavouritePlayerForTeamAndCupTaskRequest()
			{
				Cup = this.settings.Cup,
				TeamFifaCode = teamFifaCode,
				Player = player
			});

			this.RefreshDataOnPlayersTab();
		}

		private void AddFavourite(object sender, EventArgs e)
		{
			var toolStrimMenuItem = (ToolStripMenuItem)sender;
			var player = (Player)toolStrimMenuItem.Tag;

			var teamFifaCode = this.cbFavouriteTeam.SelectedValue as string;
			this.playerRepo.AddFavouritePlayerForTeamAndCupTask(new AddFavouritePlayerForTeamAndCupTaskRequest()
			{
				Cup = this.settings.Cup,
				TeamFifaCode = teamFifaCode,
				Player = player
			});

			this.RefreshDataOnPlayersTab();
		}

		#endregion
		private void cbFavouriteTeam_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ctrlTable1_SelectedIndexChanged(ctrlTable1, e);
		}

		private void cbFavouriteTeam_SelectedValueChanged(object sender, EventArgs e)
		{

		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(MessageBox.Show("Jeste li sigurni?") != DialogResult.OK)
			{
				e.Cancel = true;
			}
		}
	}
}
