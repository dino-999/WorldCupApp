using System;
using System.Collections.Generic;
using System.Text;
using WorldCup.BussinesLayer.Models;

namespace WorldCup.BussinesLayer.ViewModels
{
    public class PlayerVM : Player
    {
        public bool IsFavourite { get; set; }
    }
}
