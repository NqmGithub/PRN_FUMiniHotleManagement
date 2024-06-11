using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingReservationService
    {
        private readonly IBookingReservationRepositories _repository;

        public BookingReservationService()
        {
            _repository = new BookingReservationRepositories();
        }

        public List<BookingReservation> GetAll()
        {
            return _repository.GetBookingReservations();
        }

        public BookingReservation Get(int id)
        {
            return _repository.GetBookingReservationById(id);
        }

        public void Update(BookingReservation BookingReservation)
        {
            _repository.UpdateBookingReservation(BookingReservation);
        }

        public void Delete(int id)
        {
            _repository.DeleteBookingReservation(id);
        }

        public void Add(BookingReservation BookingReservation)
        {
            _repository.AddBookingReservation(BookingReservation);
        }
    }
}
