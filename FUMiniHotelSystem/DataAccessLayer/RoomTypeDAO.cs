using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomTypeDAO
    {
        private readonly FuminiHotelManagementContext _context;
        public RoomTypeDAO(FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public List<RoomType> GetRoomTypes()
        {
            return _context.RoomTypes.ToList();
        }

        public RoomType GetRoomType(int id)
        {
            return _context.RoomTypes.FirstOrDefault(r => r.RoomTypeId == id);
        }

        public void AddRoomType(RoomType room)
        {
            _context.RoomTypes.Add(room);
            _context.SaveChanges();
        }

        public void DeleteRoomType(int id)
        {
            var rom = GetRoomType(id);
            if (rom != null)
            {
                _context.RoomTypes.Remove(rom);
                _context.SaveChanges();
            }
        }

        public void UpdateRoomType(RoomType room)
        {
            _context.RoomTypes.Update(room);
            _context.SaveChanges();
        }
    }
}
