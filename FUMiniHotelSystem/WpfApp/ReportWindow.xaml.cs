using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private readonly BookingReservationService bookingReservationService;

        public ReportWindow()
        {
            InitializeComponent();
            bookingReservationService = new BookingReservationService();
        }

        public void Load()
        {
            var br = bookingReservationService.GetAll();
            lvBr.ItemsSource = br;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DateTime? selectedStartDate = dpStartDate.SelectedDate;
            DateTime? selectedEndDate = dpEndDate.SelectedDate;

            

            if (selectedStartDate == null && selectedEndDate == null)
            {
                var listBooking = bookingReservationService.GetAll();
                lvBr.ItemsSource = listBooking;
            }
            else
            {
                DateTime startDate = selectedStartDate ?? DateTime.Now;
                DateTime endDate = selectedEndDate?.Date ?? DateTime.Now;

                DateOnly start = DateOnly.FromDateTime(selectedStartDate.Value);
                DateOnly end = DateOnly.FromDateTime(selectedEndDate.Value);

                var filteredBookingReservation = bookingReservationService.GetAll().Select(b => b.BookingDate > start && b.BookingDate < end);
                lvBr.ItemsSource = filteredBookingReservation;
            }
        }
    }
}
