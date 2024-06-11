using BusinessObjects;
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
using WpfApp.ViewModel;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for BookDetailsWindow.xaml
    /// </summary>
    public partial class BookDetailsWindow : Window
    {

        public BookDetailsWindow()
        {
            InitializeComponent();
            LoadBooked();
            txtTotal.Text = MainViewModel.Reservation.TotalPrice.ToString();
        }

        public void LoadBooked()
        {
            bookedDataGrid.ItemsSource = MainViewModel.Reservation.BookingDetails;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.Reservation.BookingStatus = 2;
            MessageBox.Show("Good luck Have fun");
            this.Close();
        }

        private void bookedDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = bookedDataGrid.SelectedItem as BookingDetail;
            if (selected != null)
            {
                txtNumber.Text = selected.Room.RoomNumber.ToString();
                txtPrice.Text = selected.Room.RoomPricePerDay.ToString();
                txtStart.Text = selected.StartDate.ToString();
                txtEnd.Text = selected.EndDate.ToString();
                txtActual.Text = selected.ActualPrice.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListRoomWindow listRoomWindow = new ListRoomWindow();
            listRoomWindow.Show();
            this.Close();
        }
    }
}
