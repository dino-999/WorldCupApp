using System;
using System.Collections.Generic;
using System.Text;
using WorldCup.BussinesLayer.Models;

namespace WorldCup.BussinesLayer.ViewModels
{
    public class PlayerVM : Player
    {
        public bool IsFavourite { get; set; }

        public PlayerVM(Player player)
        {
            this.Name = player.Name;
            this.Captain = player.Captain;
            this.ShirtNumber = player.ShirtNumber;
            this.Position = player.Position;
        }

        public PlayerVM(Player player, bool isFavourite) : this(player)
        {
            this.IsFavourite = isFavourite;
        }
    }
}
