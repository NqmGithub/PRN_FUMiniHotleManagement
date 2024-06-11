using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingDetailRepositories
    {
        List<BookingDetail> GetBookingDetails();

        BookingDetail GetBookingDetail(int roomid, int reid);

        void UpdateBookingDetail(BookingDetail bookingDetail);

        void DeleteBookingDetail(int roomid, int reid);

        void AddBookingDetail(BookingDetail bookingDetail);
    }
}
