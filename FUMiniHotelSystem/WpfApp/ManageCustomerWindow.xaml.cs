using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ManageCustomerWindow.xaml
    /// </summary>
    public partial class ManageCustomerWindow : Window
    {
        private readonly CustomerService customerService;
        private FuminiHotelManagementContext _context = new FuminiHotelManagementContext();
        public ManageCustomerWindow()
        {
            InitializeComponent();
            customerService = new CustomerService();
            LoadData();
        }

        public void LoadData()
        {
            dtGridCustomer.ItemsSource = customerService.GetAll();
        }

        private void dtGridCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = dtGridCustomer.SelectedItem as Customer;
            if (selected != null)
            {
                txtID.Text = selected.CustomerId.ToString();
                txtName.Text = selected.CustomerFullName.ToString();
                txtPhone.Text = selected.Telephone.ToString();
                txtEmail.Text = selected.EmailAddress.ToString();
                txtBithday.Text = selected.CustomerBirthday.ToString();
                txtStatus.Text = selected.CustomerStatus.ToString();
                txtPassword.Text = selected.Password;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer cus = new Customer();
                cus.CustomerFullName = txtName.Text;
                cus.EmailAddress = txtEmail.Text;
                cus.CustomerBirthday = DateOnly.Parse(txtBithday.Text);
                cus.CustomerStatus = byte.Parse(txtStatus.Text);
                cus.Telephone = txtPhone.Text;
                customerService.Add(cus);
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
                Customer cus = customerService.Get(int.Parse(txtID.Text));
                if(cus != null)
                {
                    cus.CustomerId = int.Parse(txtID.Text);
                    cus.CustomerFullName = txtName.Text;
                    cus.EmailAddress = txtEmail.Text;
                    cus.CustomerBirthday = DateOnly.Parse(txtBithday.Text);
                    cus.CustomerStatus = byte.Parse(txtStatus.Text);
                    cus.Telephone = txtPhone.Text;
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
                customerService.Delete(int.Parse(txtID.Text));
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
            txtName.Text = "";
            txtBithday.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtStatus.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }
    }
}
