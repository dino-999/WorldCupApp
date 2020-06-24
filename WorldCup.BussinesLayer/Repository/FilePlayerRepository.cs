using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCup.BussinesLayer.Repository
{

    public interface IPlayerRepository
    {
        GetPlayersTaskResponse GetPlayersTask();
        SavePlayersTaskResponse SavePlayersTask(SavePlayerTaskRequest request);
    }
    class FilePlayerRepository : IPlayerRepository
    {
        public GetPlayersTaskResponse GetPlayersTask()
        {
            throw new NotImplementedException();
        }

        public SavePlayersTaskResponse SavePlayersTask(SavePlayerTaskRequest request)
        {
            throw new NotImplementedException();
        }
    }

    public class GetPlayersTaskResponse
    {
        public bool Succeded { ge
                t; set; } = true;
        public SettingsModel Settings { get; set; }
    }

    public class SavePlayersTaskRequest
    {
        public SettingsModel Settings { get; set; }
    }
    public class SavePlayersTaskResponse
    {
        public bool Succeded { get; set; } = true;
    }
}
