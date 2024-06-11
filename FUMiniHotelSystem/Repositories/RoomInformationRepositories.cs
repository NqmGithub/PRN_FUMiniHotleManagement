using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomInformationRepositories : IRoomInformationRepositories
    {
        private readonly FuminiHotelManagementContext _context;

        public RoomInformationRepositories()
        {
            _context = new FuminiHotelManagementContext();
        }

        public void AddRoomInformation(RoomInformation RoomInformation)
        {
            _context.RoomInformations.Add(RoomInformation);
            _context.SaveChanges();
        }

        public void DeleteRoomInformation(int id)
        {
            var cus = _context.RoomInformations.Find(id);
            if (cus != null)
            {
                _context.RoomInformations.Remove(cus);
                _context.SaveChanges();
            }
        }

        public RoomInformation GetRoomInformationById(int id)
        {
            return _context.RoomInformations.FirstOrDefault(c => c.RoomId == id);
        }

        public List<RoomInformation> GetRoomInformations()
        {
            return _context.RoomInformations.ToList();
        }

        public void UpdateRoomInformation(RoomInformation RoomInformation)
        {
            _context.RoomInformations.Update(RoomInformation);
            _context.SaveChanges();
        }
    }
}
