using System;
using System.Collections.Generic;
using System.Text;
using WorldCup.BussinesLayer.ViewModels;

namespace WorldCup.BussinesLayer.Models
{
    public class FavouriteTeamSettingsModel
    {
        public List<CupTeamWrapper> Items { get; set; }
    }

    public class CupTeamWrapper
    {
        public TeamVM Team { get; set; }
        public CupVM Cup { get; set; }
    }
}
