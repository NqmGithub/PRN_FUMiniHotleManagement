using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailRepositories :IBookingDetailRepositories
    {
        private readonly FuminiHotelManagementContext _context;

        public BookingDetailRepositories()
        {
            _context = new FuminiHotelManagementContext();
        }

        public void AddBookingDetail(BookingDetail BookingDetail)
        {
            _context.BookingDetails.Add(BookingDetail);
            _context.SaveChanges();
        }

        public void DeleteBookingDetail(int roomid, int reid)
        {
            var cus = GetBookingDetail(roomid, reid);
            if (cus != null)
            {
                _context.BookingDetails.Remove(cus);
                _context.SaveChanges();
            }
        }

        public BookingDetail GetBookingDetail(int roomid, int reid)
        {
            return _context.BookingDetails.FirstOrDefault(c => c.RoomId == roomid && c.BookingReservationId == reid);
        }

        public List<BookingDetail> GetBookingDetails()
        {
            return _context.BookingDetails.ToList();
        }

        public void UpdateBookingDetail(BookingDetail BookingDetail)
        {
            _context.BookingDetails.Update(BookingDetail);
            _context.SaveChanges();
        }
    }
}
