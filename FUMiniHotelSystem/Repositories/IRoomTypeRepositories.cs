using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomTypeRepositories
    {
        List<RoomType> GetRoomTypes();

        RoomType GetRoomTypeById(int id);

        void UpdateRoomType(RoomType roomType);

        void DeleteRoomType(int id);

        void AddRoomType(RoomType roomType);
    }
}
