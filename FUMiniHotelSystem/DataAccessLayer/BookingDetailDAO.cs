using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingDetailDAO
    {
        private readonly FuminiHotelManagementContext _context;

        public BookingDetailDAO(FuminiHotelManagementContext context)
        {
            _context = context;
        }
        public List<BookingDetail> GetBookingDetails()
        {
            return _context.BookingDetails.ToList();
        }

        public BookingDetail GetBookingDetail(int Roomid, int ReID)
        {
            return _context.BookingDetails.FirstOrDefault(c => c.RoomId == Roomid && c.BookingReservationId == ReID);
        }

        public void AddBookingDetail(BookingDetail BookingDetail)
        {
            _context.BookingDetails.Add(BookingDetail);
            _context.SaveChanges();
        }

        public void UpdateBookingDetail(BookingDetail BookingDetail)
        {
            _context.BookingDetails.Update(BookingDetail);
            _context.SaveChanges();
        }

        public void DeleteBookingDetail(int Roomid, int ReID)
        {
            var cus = GetBookingDetail(Roomid, ReID);
            if (cus != null)
            {
                _context.BookingDetails.Remove(cus);
                _context.SaveChanges();
            }
        }
    }
}
