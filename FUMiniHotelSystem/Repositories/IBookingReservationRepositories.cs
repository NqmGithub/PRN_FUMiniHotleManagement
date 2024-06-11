using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingReservationRepositories
    {
        List<BookingReservation> GetBookingReservations();

        BookingReservation GetBookingReservationById(int id);

        void UpdateBookingReservation(BookingReservation bookingReservation);

        void DeleteBookingReservation(int id);

        void AddBookingReservation(BookingReservation bookingReservation);
    }
}
