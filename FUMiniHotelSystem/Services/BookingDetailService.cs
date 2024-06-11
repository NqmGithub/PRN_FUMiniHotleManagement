using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingDetailService
    {
        private readonly IBookingDetailRepositories _repository;

        public BookingDetailService()
        {
            _repository = new BookingDetailRepositories();
        }

        public List<BookingDetail> GetAll()
        {
            return _repository.GetBookingDetails();
        }

        public BookingDetail Get(int roomid, int reid)
        {
            return _repository.GetBookingDetail(roomid, reid);
        }

        public void Update(BookingDetail BookingDetail)
        {
            _repository.UpdateBookingDetail(BookingDetail);
        }

        public void Delete(int roomid, int reid)
        {
            _repository.DeleteBookingDetail(roomid, reid);
        }

        public void Add(BookingDetail BookingDetail)
        {
            _repository.AddBookingDetail(BookingDetail);
        }
    }
}
