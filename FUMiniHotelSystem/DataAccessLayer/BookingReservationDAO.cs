using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingReservationDAO
    {
        private readonly FuminiHotelManagementContext _context;

        public BookingReservationDAO(FuminiHotelManagementContext context)
        {
            _context = context;
        }
        public List<BookingReservation> GetBookingReservations()
        {
            return _context.BookingReservations.ToList();
        }

        public BookingReservation GetBookingReservation(int id)
        {
            return _context.BookingReservations.FirstOrDefault(c => c.BookingReservationId == id);
        }

        public void AddBookingReservation(BookingReservation BookingReservation)
        {
            _context.BookingReservations.Add(BookingReservation);
            _context.SaveChanges();
        }

        public void UpdateBookingReservation(BookingReservation BookingReservation)
        {
            _context.BookingReservations.Update(BookingReservation);
            _context.SaveChanges();
        }

        public void DeleteBookingReservation(int id)
        {
            var cus = _context.BookingReservations.Find(id);
            if (cus != null)
            {
                _context.BookingReservations.Remove(cus);
                _context.SaveChanges();
            }
        }
    }
}
