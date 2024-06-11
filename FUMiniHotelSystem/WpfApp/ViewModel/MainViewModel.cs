using BusinessObjects;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly CustomerService customerService;
        private readonly RoomInformationService roomInformationService;
        private readonly BookingReservationService bookingReservationService;
        private readonly BookingDetailService bookingDetailService; 

        public ObservableCollection<Customer> customers {  get; set; }
        public ObservableCollection<RoomInformation> rooms { get; set; }

        public MainViewModel()
        {
            customerService = new CustomerService();
            roomInformationService = new RoomInformationService();
            bookingDetailService = new BookingDetailService();
            bookingReservationService = new BookingReservationService();
        }


        public static ObservableCollection<RoomInformation> BookedRooms;

        public static BookingReservation Reservation;

        public static Customer current;
    }
}
