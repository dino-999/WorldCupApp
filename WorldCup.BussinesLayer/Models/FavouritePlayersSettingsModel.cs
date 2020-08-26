using System;
using System.Collections.Generic;
using System.Text;
using WorldCup.BussinesLayer.ViewModels;

namespace WorldCup.BussinesLayer.Models
{
    public class FavouritePlayersSettingsModel
    {
        public List<CupTeamPlayerWrapper> Players { get; set; }
    }

    public class CupTeamPlayerWrapper
    {
        public CupVM Cup { get; set; }
        public string TeamFifaCode { get; set; }
        public Player Player { get; set; }
    }
}
