using System;
using System.Collections.Generic;
using System.Text;
using WorldCup.BussinesLayer.Models;

namespace WorldCup.BussinesLayer.ViewModels
{
    public class TeamVM : Team
    {
        //Nothing do far...
        public TeamVM()
        {

        }
        public TeamVM(int id, string country, string alternateName, string fifaCode, int groupId, string groupLetter)
        {
            this.Id= id;
            this.Country = country;
            this.AlternateName = alternateName;
            this.FifaCode = fifaCode;
            this.GroupId = groupId;
            this.GroupLetter = groupLetter;
        }
    }
}
