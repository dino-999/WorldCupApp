namespace WorldCup.WindwosForm
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.cbFavouriteTeam = new System.Windows.Forms.ComboBox();
			this.lblFavouriteTeam = new System.Windows.Forms.Label();
			this.btnSettings = new System.Windows.Forms.Button();
			this.btnMakeFavourite = new System.Windows.Forms.Button();
			this.ctrlTable1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.flpFavourites = new System.Windows.Forms.FlowLayoutPanel();
			this.flpAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnPrint = new System.Windows.Forms.Button();
			this.dgvShowPlayerInfo = new System.Windows.Forms.DataGridView();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.btnPrintRangList2 = new System.Windows.Forms.Button();
			this.dgvShowMatchInfo = new System.Windows.Forms.DataGridView();
			this.NumberOfWatchers = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.HomeTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AwayTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStripMenuPageSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuChoosePrinter = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuPrint = new System.Windows.Forms.ToolStripMenuItem();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.printDocument2 = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog2 = new System.Windows.Forms.PrintPreviewDialog();
			this.NameOfPlayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.YellowCards = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NumberOfGamesPlayed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ImageFilePath = new System.Windows.Forms.DataGridViewImageColumn();
			this.ScoredGoals = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ctrlTable1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvShowPlayerInfo)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvShowMatchInfo)).BeginInit();
			this.SuspendLayout();
			// 
			// cbFavouriteTeam
			// 
			this.cbFavouriteTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFavouriteTeam.FormattingEnabled = true;
			this.cbFavouriteTeam.Location = new System.Drawing.Point(180, 45);
			this.cbFavouriteTeam.Name = "cbFavouriteTeam";
			this.cbFavouriteTeam.Size = new System.Drawing.Size(183, 21);
			this.cbFavouriteTeam.TabIndex = 0;
			this.cbFavouriteTeam.SelectedIndexChanged += new System.EventHandler(this.cbFavouriteTeam_SelectedIndexChanged);
			
			// 
			// lblFavouriteTeam
			// 
			this.lblFavouriteTeam.AutoSize = true;
			this.lblFavouriteTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.lblFavouriteTeam.Location = new System.Drawing.Point(12, 46);
			this.lblFavouriteTeam.Name = "lblFavouriteTeam";
			this.lblFavouriteTeam.Size = new System.Drawing.Size(157, 17);
			this.lblFavouriteTeam.TabIndex = 1;
			this.lblFavouriteTeam.Text = "Omiljena reprezentacija";
			// 
			// btnSettings
			// 
			this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSettings.Location = new System.Drawing.Point(976, 45);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(75, 23);
			this.btnSettings.TabIndex = 2;
			this.btnSettings.Text = "Postavke";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			// 
			// btnMakeFavourite
			// 
			this.btnMakeFavourite.Location = new System.Drawing.Point(384, 41);
			this.btnMakeFavourite.Name = "btnMakeFavourite";
			this.btnMakeFavourite.Size = new System.Drawing.Size(156, 27);
			this.btnMakeFavourite.TabIndex = 3;
			this.btnMakeFavourite.Text = "Označi kao omiljeni";
			this.btnMakeFavourite.UseVisualStyleBackColor = true;
			this.btnMakeFavourite.Click += new System.EventHandler(this.btnMakeFavourite_Click);
			// 
			// ctrlTable1
			// 
			this.ctrlTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ctrlTable1.Controls.Add(this.tabPage1);
			this.ctrlTable1.Controls.Add(this.tabPage2);
			this.ctrlTable1.Controls.Add(this.tabPage3);
			this.ctrlTable1.Location = new System.Drawing.Point(15, 105);
			this.ctrlTable1.Name = "ctrlTable1";
			this.ctrlTable1.SelectedIndex = 0;
			this.ctrlTable1.Size = new System.Drawing.Size(1060, 527);
			this.ctrlTable1.TabIndex = 4;
			this.ctrlTable1.SelectedIndexChanged += new System.EventHandler(this.ctrlTable1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.flpFavourites);
			this.tabPage1.Controls.Add(this.flpAllPlayers);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1052, 501);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Igrači";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(645, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Favoriti";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Svi";
			// 
			// flpFavourites
			// 
			this.flpFavourites.AutoScroll = true;
			this.flpFavourites.Location = new System.Drawing.Point(648, 54);
			this.flpFavourites.Name = "flpFavourites";
			this.flpFavourites.Size = new System.Drawing.Size(384, 423);
			this.flpFavourites.TabIndex = 3;
			// 
			// flpAllPlayers
			// 
			this.flpAllPlayers.AutoScroll = true;
			this.flpAllPlayers.Location = new System.Drawing.Point(16, 54);
			this.flpAllPlayers.Name = "flpAllPlayers";
			this.flpAllPlayers.Size = new System.Drawing.Size(345, 423);
			this.flpAllPlayers.TabIndex = 2;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnPrint);
			this.tabPage2.Controls.Add(this.dgvShowPlayerInfo);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1052, 501);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Rang lista 1";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnPrint
			// 
			this.btnPrint.Location = new System.Drawing.Point(957, 26);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(75, 23);
			this.btnPrint.TabIndex = 2;
			this.btnPrint.Text = "Print";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// dgvShowPlayerInfo
			// 
			this.dgvShowPlayerInfo.AllowUserToAddRows = false;
			this.dgvShowPlayerInfo.AllowUserToDeleteRows = false;
			this.dgvShowPlayerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvShowPlayerInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameOfPlayer,
            this.YellowCards,
            this.NumberOfGamesPlayed,
            this.ImageFilePath,
            this.ScoredGoals});
			this.dgvShowPlayerInfo.Location = new System.Drawing.Point(22, 16);
			this.dgvShowPlayerInfo.Name = "dgvShowPlayerInfo";
			this.dgvShowPlayerInfo.ReadOnly = true;
			this.dgvShowPlayerInfo.Size = new System.Drawing.Size(909, 462);
			this.dgvShowPlayerInfo.TabIndex = 1;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.btnPrintRangList2);
			this.tabPage3.Controls.Add(this.dgvShowMatchInfo);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(1052, 501);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Rang lista 2";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// btnPrintRangList2
			// 
			this.btnPrintRangList2.Location = new System.Drawing.Point(924, 19);
			this.btnPrintRangList2.Name = "btnPrintRangList2";
			this.btnPrintRangList2.Size = new System.Drawing.Size(75, 23);
			this.btnPrintRangList2.TabIndex = 1;
			this.btnPrintRangList2.Text = "Print";
			this.btnPrintRangList2.UseVisualStyleBackColor = true;
			this.btnPrintRangList2.Click += new System.EventHandler(this.btnPrintRangList2_Click);
			// 
			// dgvShowMatchInfo
			// 
			this.dgvShowMatchInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvShowMatchInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumberOfWatchers,
            this.Location,
            this.HomeTeam,
            this.AwayTeam});
			this.dgvShowMatchInfo.Location = new System.Drawing.Point(21, 19);
			this.dgvShowMatchInfo.Name = "dgvShowMatchInfo";
			this.dgvShowMatchInfo.Size = new System.Drawing.Size(835, 461);
			this.dgvShowMatchInfo.TabIndex = 0;
			// 
			// NumberOfWatchers
			// 
			this.NumberOfWatchers.DataPropertyName = "NumberOfWatchers";
			this.NumberOfWatchers.HeaderText = "Gledatelji";
			this.NumberOfWatchers.Name = "NumberOfWatchers";
			this.NumberOfWatchers.ReadOnly = true;
			// 
			// Location
			// 
			this.Location.DataPropertyName = "Location";
			this.Location.HeaderText = "Lokacija";
			this.Location.Name = "Location";
			this.Location.ReadOnly = true;
			// 
			// HomeTeam
			// 
			this.HomeTeam.DataPropertyName = "HomeTeam";
			this.HomeTeam.HeaderText = "Domaći";
			this.HomeTeam.Name = "HomeTeam";
			this.HomeTeam.ReadOnly = true;
			// 
			// AwayTeam
			// 
			this.AwayTeam.DataPropertyName = "AwayTeam";
			this.AwayTeam.HeaderText = "Gosti";
			this.AwayTeam.Name = "AwayTeam";
			this.AwayTeam.ReadOnly = true;
			// 
			// toolStripMenuPageSettings
			// 
			this.toolStripMenuPageSettings.Name = "toolStripMenuPageSettings";
			this.toolStripMenuPageSettings.Size = new System.Drawing.Size(32, 19);
			// 
			// toolStripMenuChoosePrinter
			// 
			this.toolStripMenuChoosePrinter.Name = "toolStripMenuChoosePrinter";
			this.toolStripMenuChoosePrinter.Size = new System.Drawing.Size(32, 19);
			// 
			// toolStripMenuPrintPreview
			// 
			this.toolStripMenuPrintPreview.Name = "toolStripMenuPrintPreview";
			this.toolStripMenuPrintPreview.Size = new System.Drawing.Size(32, 19);
			// 
			// toolStripMenuPrint
			// 
			this.toolStripMenuPrint.Name = "toolStripMenuPrint";
			this.toolStripMenuPrint.Size = new System.Drawing.Size(32, 19);
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Document = this.printDocument1;
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Visible = false;
			// 
			// printDocument2
			// 
			this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
			// 
			// printPreviewDialog2
			// 
			this.printPreviewDialog2.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog2.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog2.Document = this.printDocument2;
			this.printPreviewDialog2.Enabled = true;
			this.printPreviewDialog2.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog2.Icon")));
			this.printPreviewDialog2.Name = "printPreviewDialog2";
			this.printPreviewDialog2.Visible = false;
			// 
			// NameOfPlayer
			// 
			this.NameOfPlayer.DataPropertyName = "Name";
			this.NameOfPlayer.HeaderText = "Ime i prezime";
			this.NameOfPlayer.Name = "NameOfPlayer";
			this.NameOfPlayer.ReadOnly = true;
			// 
			// YellowCards
			// 
			this.YellowCards.DataPropertyName = "YellowCards";
			this.YellowCards.HeaderText = "Žuti kartoni";
			this.YellowCards.Name = "YellowCards";
			this.YellowCards.ReadOnly = true;
			// 
			// NumberOfGamesPlayed
			// 
			this.NumberOfGamesPlayed.DataPropertyName = "NumberOfGamesPlayed";
			this.NumberOfGamesPlayed.HeaderText = "Odigrane utakmice";
			this.NumberOfGamesPlayed.Name = "NumberOfGamesPlayed";
			this.NumberOfGamesPlayed.ReadOnly = true;
			// 
			// ImageFilePath
			// 
			this.ImageFilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.ImageFilePath.HeaderText = "Slika igrača";
			this.ImageFilePath.Name = "ImageFilePath";
			this.ImageFilePath.ReadOnly = true;
			this.ImageFilePath.Width = 61;
			// 
			// ScoredGoals
			// 
			this.ScoredGoals.DataPropertyName = "ScoredGoals";
			this.ScoredGoals.HeaderText = "Ostvareni Golovi";
			this.ScoredGoals.Name = "ScoredGoals";
			this.ScoredGoals.ReadOnly = true;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1087, 644);
			this.Controls.Add(this.ctrlTable1);
			this.Controls.Add(this.btnMakeFavourite);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.lblFavouriteTeam);
			this.Controls.Add(this.cbFavouriteTeam);
			this.MinimumSize = new System.Drawing.Size(1103, 683);
			this.Name = "Main";
			this.Text = "Main";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.Load += new System.EventHandler(this.Main_Load);
			this.ctrlTable1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvShowPlayerInfo)).EndInit();
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvShowMatchInfo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.ComboBox cbFavouriteTeam;
        private System.Windows.Forms.Label lblFavouriteTeam;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnMakeFavourite;
        private System.Windows.Forms.TabControl ctrlTable1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuPageSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuChoosePrinter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuPrintPreview;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.FlowLayoutPanel flpAllPlayers;
        private System.Windows.Forms.FlowLayoutPanel flpFavourites;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgvShowPlayerInfo;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.DataGridView dgvShowMatchInfo;
		private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfWatchers;
		private System.Windows.Forms.DataGridViewTextBoxColumn Location;
		private System.Windows.Forms.DataGridViewTextBoxColumn HomeTeam;
		private System.Windows.Forms.DataGridViewTextBoxColumn AwayTeam;
		private System.Windows.Forms.Button btnPrintRangList2;
		private System.Drawing.Printing.PrintDocument printDocument2;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog2;
		private System.Windows.Forms.DataGridViewTextBoxColumn NameOfPlayer;
		private System.Windows.Forms.DataGridViewTextBoxColumn YellowCards;
		private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfGamesPlayed;
		private System.Windows.Forms.DataGridViewImageColumn ImageFilePath;
		private System.Windows.Forms.DataGridViewTextBoxColumn ScoredGoals;
	}
}