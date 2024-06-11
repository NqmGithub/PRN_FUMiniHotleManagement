using BusinessObjects;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ListRoomWindow.xaml
    /// </summary>
    public partial class ListRoomWindow : Window
    {
        private readonly RoomInformationService roomInformationService;
        private readonly RoomTypeService roomTypeService;
        private readonly BookingReservationService bookingReservationService;
        private readonly BookingDetailService bookingDetailService;
        public ObservableCollection<RoomInformation> rooms { get; set; }
        public ListRoomWindow()
        {
            InitializeComponent();
            roomInformationService = new RoomInformationService();
            roomTypeService = new RoomTypeService();
            bookingReservationService = new BookingReservationService();
            bookingDetailService = new BookingDetailService();
            rooms = new ObservableCollection<RoomInformation>(roomInformationService.GetAll());
            LoadData();
        }

        public void LoadData()
        {
            RoomDataGrid.ItemsSource = rooms;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = RoomDataGrid.SelectedItem as RoomInformation;
            if (selected != null)
            {
                txtCapacity.Text = selected.RoomMaxCapacity.ToString();
                txtPrice.Text = selected.RoomPricePerDay.ToString();
                txtRoomNumber.Text = selected.RoomNumber.ToString();
                txtDescription.Text = selected.RoomDetailDescription;
                txtType.Text = roomTypeService.Get(selected.RoomTypeId).RoomTypeName;
                txtStatus.Text = selected.RoomStatus.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = RoomDataGrid.SelectedItem as RoomInformation;
            if (!DateOnly.TryParse(txtStart.Text, out DateOnly start) || !DateOnly.TryParse(txtEnd.Text, out DateOnly end))
            {
                MessageBox.Show("Must input valid date");
                return;
            }
            else
            {
                if (selected != null)
                {
                    if(MainViewModel.Reservation == null)
                    {
                        BookingReservation bookingReservation = new BookingReservation();
                        bookingReservation.Customer = MainViewModel.current;
                        bookingReservation.CustomerId = MainViewModel.current.CustomerId;
                        bookingReservation.BookingDate = DateOnly.FromDateTime(DateTime.Today);
                        bookingReservation.BookingStatus = 1;
                        bookingReservation.TotalPrice = 0;
                        bookingReservation.BookingDetails = new List<BookingDetail>();
                        MainViewModel.Reservation = bookingReservation;
                    }
                    
                    BookingDetail bookDetail = new BookingDetail();
                    bookDetail.StartDate = start;
                    bookDetail.EndDate = end;

                    var difference = end.DayNumber - start.DayNumber;
                    bookDetail.ActualPrice = Decimal.Parse(txtPrice.Text) * difference;

                    bookDetail.Room = selected;
                    bookDetail.RoomId = selected.RoomId;
                    bookDetail.BookingReservation = MainViewModel.Reservation;

                    MainViewModel.Reservation.TotalPrice += bookDetail.ActualPrice;
                    MainViewModel.Reservation.BookingDetails.Add(bookDetail);

/*                    bookingReservationService.Update(MainViewModel.Reservation);
                    bookingDetailService.Add(bookDetail);*/

                    BookDetailsWindow bookDetailsWindow = new BookDetailsWindow();
                    bookDetailsWindow.Show();
                    this.Close();
                }
            }
            
        }
    }
}
