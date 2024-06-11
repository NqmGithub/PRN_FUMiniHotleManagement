using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomDAO
    {
        private readonly FuminiHotelManagementContext _context;
        public RoomDAO(FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public List<RoomInformation> GetRooms()
        {
            return _context.RoomInformations.ToList();
        }

        public RoomInformation GetRoom(int id)
        {
            return _context.RoomInformations.FirstOrDefault(r => r.RoomId == id);
        }

        public void AddRoom(RoomInformation room)
        {
            _context.RoomInformations.Add(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var rom = GetRoom(id);
            if (rom != null)
            {
                _context.RoomInformations.Remove(rom);
                _context.SaveChanges();
            }
        }

        public void UpdateRoom(RoomInformation room)
        {
            _context.RoomInformations.Update(room);
            _context.SaveChanges();
        }
    }
}
