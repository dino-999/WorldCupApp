namespace WorldCup.WindwosForm
{
    partial class PlayerUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerUC));
            this.lblName = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.pbPlayerImage = new System.Windows.Forms.PictureBox();
            this.pbFavourite = new System.Windows.Forms.PictureBox();
            this.lblCaptain = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName.Location = new System.Drawing.Point(72, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Dino Jagar";
            // 
            // lblShirtNumber
            // 
            this.lblShirtNumber.AutoSize = true;
            this.lblShirtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblShirtNumber.Location = new System.Drawing.Point(263, 49);
            this.lblShirtNumber.Name = "lblShirtNumber";
            this.lblShirtNumber.Size = new System.Drawing.Size(30, 24);
            this.lblShirtNumber.TabIndex = 1;
            this.lblShirtNumber.Text = "23";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(72, 25);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(40, 13);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "obrana";
            // 
            // pbPlayerImage
            // 
            this.pbPlayerImage.Location = new System.Drawing.Point(17, 25);
            this.pbPlayerImage.Name = "pbPlayerImage";
            this.pbPlayerImage.Size = new System.Drawing.Size(49, 38);
            this.pbPlayerImage.TabIndex = 3;
            this.pbPlayerImage.TabStop = false;
            // 
            // pbFavourite
            // 
            this.pbFavourite.BackColor = System.Drawing.SystemColors.Control;
            this.pbFavourite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbFavourite.Image = ((System.Drawing.Image)(resources.GetObject("pbFavourite.Image")));
            this.pbFavourite.Location = new System.Drawing.Point(267, 3);
            this.pbFavourite.Name = "pbFavourite";
            this.pbFavourite.Size = new System.Drawing.Size(26, 22);
            this.pbFavourite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFavourite.TabIndex = 4;
            this.pbFavourite.TabStop = false;
            // 
            // lblCaptain
            // 
            this.lblCaptain.AutoSize = true;
            this.lblCaptain.Location = new System.Drawing.Point(72, 50);
            this.lblCaptain.Name = "lblCaptain";
            this.lblCaptain.Size = new System.Drawing.Size(47, 13);
            this.lblCaptain.TabIndex = 5;
            this.lblCaptain.Text = "Kapetan";
            // 
            // PlayerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Controls.Add(this.lblCaptain);
            this.Controls.Add(this.pbFavourite);
            this.Controls.Add(this.pbPlayerImage);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblShirtNumber);
            this.Controls.Add(this.lblName);
            this.Name = "PlayerUC";
            this.Size = new System.Drawing.Size(296, 83);
            this.Load += new System.EventHandler(this.PlayerUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblShirtNumber;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.PictureBox pbPlayerImage;
        private System.Windows.Forms.PictureBox pbFavourite;
        private System.Windows.Forms.Label lblCaptain;
    }
}
