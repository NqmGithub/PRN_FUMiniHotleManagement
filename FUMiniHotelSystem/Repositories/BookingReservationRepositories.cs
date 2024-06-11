using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingReservationRepositories : IBookingReservationRepositories
    {
        private readonly FuminiHotelManagementContext _context;

        public BookingReservationRepositories()
        {
            _context = new FuminiHotelManagementContext();
        }

        public void AddBookingReservation(BookingReservation BookingReservation)
        {
            _context.BookingReservations.Add(BookingReservation);
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

        public BookingReservation GetBookingReservationById(int id)
        {
            return _context.BookingReservations.FirstOrDefault(c => c.BookingReservationId == id);
        }

        public List<BookingReservation> GetBookingReservations()
        {
            return _context.BookingReservations.ToList();
        }

        public void UpdateBookingReservation(BookingReservation BookingReservation)
        {
            _context.BookingReservations.Update(BookingReservation);
            _context.SaveChanges();
        }
    }
}
