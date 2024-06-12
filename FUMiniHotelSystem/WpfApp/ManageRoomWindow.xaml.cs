using BusinessObjects;
using DataAccessLayer;
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
using System.Xml.Linq;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ManageRoomWindow.xaml
    /// </summary>
    public partial class ManageRoomWindow : Window
    {
        private readonly RoomInformationService roomService;
        private readonly RoomTypeService roomTypeService;
        public ObservableCollection<string> roomTypeNames;
        private FuminiHotelManagementContext _context = new FuminiHotelManagementContext();
        public ManageRoomWindow()
        {
            InitializeComponent();
            roomService = new RoomInformationService();
            roomTypeService = new RoomTypeService();
            LoadData();
        }

        public void LoadData()
        {
            dtGridRoom.ItemsSource = roomService.GetAll();

            cboType.ItemsSource = roomTypeService.GetAll();
            cboType.DisplayMemberPath = "RoomTypeName";
            cboType.SelectedValuePath = "RoomTypeId";
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
                cboType.SelectedValue = selected.RoomTypeId;
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
                ResetInputFields();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomInformation room = roomService.Get(int.Parse(txtID.Text));
                if (room != null)
                {
                    room.RoomMaxCapacity = int.Parse(txtCapacity.Text);
                    room.RoomDetailDescription = txtDescription.Text;
                    room.RoomNumber = txtNumber.Text;
                    room.RoomPricePerDay = Decimal.Parse(txtPrice.Text);
                    room.RoomStatus = byte.Parse(txtStatus.Text);
                    room.RoomTypeId = int.Parse(txtType.Text);
                    _context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadData();
                ResetInputFields();
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
                ResetInputFields();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
            this.Close();
        }

        private void ResetInputFields()
        {
            txtID.Text = string.Empty;
            txtDescription.Text = "";
            txtCapacity.Text = "";
            txtPrice.Text = "";
            txtNumber.Text = "";
            cboType.SelectedValue = -1;
        }
    }
}
