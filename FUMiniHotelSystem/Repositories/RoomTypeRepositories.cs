using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomTypeRepositories : IRoomTypeRepositories
    {
        private readonly FuminiHotelManagementContext _context;

        public RoomTypeRepositories()
        {
            _context = new FuminiHotelManagementContext();
        }

        public void AddRoomType(RoomType RoomType)
        {
            _context.RoomTypes.Add(RoomType);
            _context.SaveChanges();
        }

        public void DeleteRoomType(int id)
        {
            var cus = _context.RoomTypes.Find(id);
            if (cus != null)
            {
                _context.RoomTypes.Remove(cus);
                _context.SaveChanges();
            }
        }

        public RoomType GetRoomTypeById(int id)
        {
            return _context.RoomTypes.FirstOrDefault(c => c.RoomTypeId == id);
        }

        public List<RoomType> GetRoomTypes()
        {
            return _context.RoomTypes.ToList();
        }

        public void UpdateRoomType(RoomType RoomType)
        {
            _context.RoomTypes.Update(RoomType);
            _context.SaveChanges();
        }
    }
}
