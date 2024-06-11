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
using System.Xml.Linq;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ManageRoomWindow.xaml
    /// </summary>
    public partial class ManageRoomWindow : Window
    {
        private readonly RoomInformationService roomService;
        public ManageRoomWindow()
        {
            InitializeComponent();
            roomService = new RoomInformationService();
            LoadData();
        }

        public void LoadData()
        {
            dtGridRoom.ItemsSource = roomService.GetAll();
        }

        private void dtGridRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = dtGridRoom.SelectedItem as RoomInformation;
            if (selected != null)
            {
                txtID.Text = selected.RoomId.ToString();
                txtStatus.Text = selected.RoomStatus.ToString();
                txtCapacity.Text = selected.RoomMaxCapacity.ToString();
                txtDescription.Text = selected.RoomDetailDescription;
                txtNumber.Text = selected?.RoomNumber.ToString();
                txtPrice.Text = selected.RoomPricePerDay.ToString();
                txtType.Text = selected?.RoomTypeId.ToString();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomInformation room = new RoomInformation();
                room.RoomMaxCapacity = int.Parse(txtCapacity.Text);
                room.RoomDetailDescription = txtDescription.Text;
                room.RoomNumber = txtNumber.Text;
                room.RoomPricePerDay = Decimal.Parse(txtPrice.Text);
                room.RoomStatus = byte.Parse(txtStatus.Text);
                room.RoomTypeId = int.Parse(txtType.Text);

                roomService.Add(room);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomInformation room = new RoomInformation();
                room.RoomMaxCapacity = int.Parse(txtCapacity.Text);
                room.RoomDetailDescription = txtDescription.Text;
                room.RoomNumber = txtNumber.Text;
                room.RoomPricePerDay = Decimal.Parse(txtPrice.Text);
                room.RoomStatus = byte.Parse(txtStatus.Text);
                room.RoomTypeId = int.Parse(txtType.Text);

                roomService.Update(room);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                roomService.Delete(int.Parse(txtID.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadData();
            }
        }
    }
}
