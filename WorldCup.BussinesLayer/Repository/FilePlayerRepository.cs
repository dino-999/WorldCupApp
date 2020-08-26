using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCup.BussinesLayer.Repository
{
    public interface IPLayerRepository
    {
        GetFavouritePlayersForTeamAndCupTaskResponse GetFavouritePlayersForTeamAndCupTask(GetFavouritePlayersForTeamAndCupTaskRequest request);
        AddFavouritePlayerForTeamAndCupTaskResponse AddFavouritePlayerForTeamAndCupTask(AddFavouritePlayerForTeamAndCupTaskRequest request);
        RemoveFavouritePlayerForTeamAndCupTaskResponse RemoveFavouritePlayerForTeamAndCupTask(RemoveFavouritePlayerForTeamAndCupTaskRequest request);
    }


    public class FilePlayerRepository : IPLayerRepository
    {
        public GetFavouritePlayersForTeamAndCupTaskResponse GetFavouritePlayersForTeamAndCupTask(GetFavouritePlayersForTeamAndCupTaskRequest request)
        {
            throw new NotImplementedException();
        }
    }

    public class GetFavouritePlayersForTeamAndCupTaskRequest
    {
    }

    public class GetFavouritePlayersForTeamAndCupTaskResponse
    {
    }
    public class RemoveFavouritePlayerForTeamAndCupTaskResponse
    {
    }

    public class RemoveFavouritePlayerForTeamAndCupTaskRequest
    {
    }

    public class AddFavouritePlayerForTeamAndCupTaskResponse
    {
    }

    public class AddFavouritePlayerForTeamAndCupTaskRequest
    {
    }
}
