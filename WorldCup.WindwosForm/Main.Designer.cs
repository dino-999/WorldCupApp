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
            this.cbFavouriteTeam = new System.Windows.Forms.ComboBox();
            this.lblFavouriteTeam = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnMakeFavourite = new System.Windows.Forms.Button();
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
            this.btnSettings.Location = new System.Drawing.Point(976, 45);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "button1";
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 644);
            this.Controls.Add(this.btnMakeFavourite);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblFavouriteTeam);
            this.Controls.Add(this.cbFavouriteTeam);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.ComboBox cbFavouriteTeam;
        private System.Windows.Forms.Label lblFavouriteTeam;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnMakeFavourite;
    }
}