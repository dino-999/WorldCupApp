using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.BussinesLayer.Models;
using WorldCup.BussinesLayer.ViewModels;

namespace WorldCup.WindwosForm
{
    public partial class PlayerUC : UserControl
    {
        private readonly PlayerVM player;

        public PlayerUC(PlayerVM player)
        {
            InitializeComponent();
            this.player = player;
        }

        private void PlayerUC_Load(object sender, EventArgs e)
        {
            lblName.Text = this.player.Name;
            lblPosition.Text = this.player.Position;
            lblShirtNumber.Text = this.player.ShirtNumber.ToString();
            pbFavourite.Visible = this.player.IsFavourite;
            lblCaptain.Visible =  this.player.Captain;
            //Slika...
        }
    }
}
