using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WorldCup.BussinesLayer.Models;
using WorldCup.BussinesLayer.ViewModels;

namespace WorldCup.BussinesLayer.Repository
{
    public interface ITeamsRepository
    {
        GetTeamsTaskResponse GetTeamsTask(GetTeamsTaskRequest request);
        SaveFavouriteTeamTaskResponse SaveFavouriteTeamsTask(SaveFavouriteTeamTaskRequest request);

        GetFavouriteTeamTaskResponse GetFavouriteTeamTask(GetFavouriteTeamTaskRequest request);
    }


    public class FileTeamsRepository : ITeamsRepository
    {
        public GetFavouriteTeamTaskResponse GetFavouriteTeamTask(GetFavouriteTeamTaskRequest request)
        {

            FavouriteTeamSettingsModel favouriteTeamSettingsModel = this.GetFavouriteTeamSettings();  //Convert from json

            if (favouriteTeamSettingsModel == null)
            {
                return new GetFavouriteTeamTaskResponse();
            }
            TeamVM favouriteTeam = favouriteTeamSettingsModel.Items.Where(x => x.Cup.Name == request.Cup.Name).Select(x => x.Team).FirstOrDefault();

            return new GetFavouriteTeamTaskResponse()//Objekt upakiraj u response i vrati ga nazad
            {
                Team = favouriteTeam

            };


        }

        public GetTeamsTaskResponse GetTeamsTask(GetTeamsTaskRequest request)
        {
            if (request.Cup.Name == "Muško prvenstvo")
            {
                return new GetTeamsTaskResponse()
                {
                    Teams = new List<TeamVM>()
                {
                    new TeamVM()
                    {
                        Country="Hrvatksa",
                        FifaCode="CRO"
                    },
                    new TeamVM
                    {
                        Country="Francuska",
                        FifaCode="FRA"
                    }
                }
                };
            }
            else
            {
                return new GetTeamsTaskResponse()
                {
                    Teams = new List<TeamVM>()
                {
                    new TeamVM()
                    {
                        Country="Španjolska",
                        FifaCode="SPA"
                    },
                    new TeamVM
                    {
                        Country="Engleska",
                        FifaCode="ENG"
                    }
                }
                };
            }
        }

        public SaveFavouriteTeamTaskResponse SaveFavouriteTeamsTask(SaveFavouriteTeamTaskRequest request)
        {
            FavouriteTeamSettingsModel favouriteTeamSettingsModel = this.GetFavouriteTeamSettings();  //Convert from json
            if (favouriteTeamSettingsModel == null)
            {
                //Nisam našao ništa u settingsu potrebno je spremiti novi settings s 1 unosom
                favouriteTeamSettingsModel = new FavouriteTeamSettingsModel();
                favouriteTeamSettingsModel.Items = new List<CupTeamWrapper>();
                favouriteTeamSettingsModel.Items.Add(new CupTeamWrapper()
                {
                    Team = request.Team,
                    Cup = request.Cup
                });

            }
            else
            {
                //Našao sam settings moram ažurirati favourite team za odabrani cup. Postoji mogučnost da u postavkama nije spremljen team za moj cup, u tom slučaju u listu moram dodati svoj unos.

                if (favouriteTeamSettingsModel.Items == null)
                {
                    favouriteTeamSettingsModel.Items = new List<CupTeamWrapper>();

                }
                var cupTeamWrapper = favouriteTeamSettingsModel.Items.Where(x => x.Cup.Name == request.Cup.Name).FirstOrDefault();
                if (cupTeamWrapper == null)
                {
                    favouriteTeamSettingsModel.Items.Add(new CupTeamWrapper()
                    {
                        Team = request.Team,
                        Cup = request.Cup
                    });


                }
                else
                {
                    cupTeamWrapper.Team = request.Team;
                }
            }
            using (StreamWriter sw = new StreamWriter(PathsConstants.FavouriteTeamSettingsFilePath))
            {

                var json = JsonConvert.SerializeObject(favouriteTeamSettingsModel);//Prebaci request u json
                sw.Write(json); //Zpis jsona u file
            }
            return new SaveFavouriteTeamTaskResponse(); //Vrati response

        }

        private FavouriteTeamSettingsModel GetFavouriteTeamSettings()
        {
            if (!File.Exists(PathsConstants.FavouriteTeamSettingsFilePath))
            {
                File.Create(PathsConstants.FavouriteTeamSettingsFilePath).Dispose();
            }
            using (StreamReader sr = new StreamReader(PathsConstants.FavouriteTeamSettingsFilePath))
            {


                var json = sr.ReadToEnd();  // Pročitaj string iz file-a

                if (string.IsNullOrEmpty(json))
                {
                    return null;
                }


                FavouriteTeamSettingsModel favouriteTeamSettingsModel = JsonConvert.DeserializeObject<FavouriteTeamSettingsModel>(json);   //Convert from json


                return favouriteTeamSettingsModel;

            }
        }
    }

    public class GetTeamsTaskRequest
    {
        public CupVM Cup { get; set; }
    }

    public class GetFavouriteTeamTaskRequest
    {
        public CupVM Cup { get; set; }
    }

    public class GetFavouriteTeamTaskResponse
    {
        public TeamVM Team { get; set; }


    }

    public class GetTeamsTaskResponse
    {
        public List<TeamVM> Teams { get; set; }
    }

    public class SaveFavouriteTeamTaskResponse
    {
        public bool Suceeded { get; set; } = true;
    }

    public class SaveFavouriteTeamTaskRequest
    {
        public TeamVM Team { get; set; }
        public CupVM Cup { get; set; }
    }

}
