namespace WorldCup.WindwosForm
{
	partial class Settings
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
            this.cbGenderSelection = new System.Windows.Forms.ComboBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.lblFormName = new System.Windows.Forms.Label();
            this.lblGenderSelection = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbGenderSelection
            // 
            this.cbGenderSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenderSelection.FormattingEnabled = true;
            this.cbGenderSelection.Location = new System.Drawing.Point(110, 54);
            this.cbGenderSelection.Name = "cbGenderSelection";
            this.cbGenderSelection.Size = new System.Drawing.Size(199, 21);
            this.cbGenderSelection.TabIndex = 0;
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] {
            "Hrvatski",
            "Engleski"});
            this.cbLanguage.Location = new System.Drawing.Point(110, 112);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(199, 21);
            this.cbLanguage.TabIndex = 1;
            // 
            // lblFormName
            // 
            this.lblFormName.AutoSize = true;
            this.lblFormName.Location = new System.Drawing.Point(12, 9);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(52, 13);
            this.lblFormName.TabIndex = 2;
            this.lblFormName.Text = "Postavke";
            // 
            // lblGenderSelection
            // 
            this.lblGenderSelection.AutoSize = true;
            this.lblGenderSelection.Location = new System.Drawing.Point(12, 57);
            this.lblGenderSelection.Name = "lblGenderSelection";
            this.lblGenderSelection.Size = new System.Drawing.Size(72, 13);
            this.lblGenderSelection.TabIndex = 3;
            this.lblGenderSelection.Text = "Muški/Ženski";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(12, 115);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(31, 13);
            this.lblLanguage.TabIndex = 4;
            this.lblLanguage.Text = "Jezik";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(234, 181);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Spremi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(110, 181);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Zatvori";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 246);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblGenderSelection);
            this.Controls.Add(this.lblFormName);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.cbGenderSelection);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbGenderSelection;
		private System.Windows.Forms.ComboBox cbLanguage;
		private System.Windows.Forms.Label lblFormName;
		private System.Windows.Forms.Label lblGenderSelection;
		private System.Windows.Forms.Label lblLanguage;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
	}
}

