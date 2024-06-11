using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomInformationRepositories
    {
        List<RoomInformation> GetRoomInformations();

        RoomInformation GetRoomInformationById(int id);

        void UpdateRoomInformation(RoomInformation Room);

        void DeleteRoomInformation(int id);

        void AddRoomInformation(RoomInformation Room);
    }
}
