using BusinessObjects;
using Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.ViewModel;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly CustomerService customerService = new CustomerService();
        public LoginWindow()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            Customer customer = customerService.GetByNamePassword(username, password);
            if(customer != null )
            {
                if (username == "admin")
                {
                    MainViewModel.current = customer;
                    ManagerWindow managerWindow = new ManagerWindow();
                    managerWindow.Show();
                    this.Close();
                }
                else
                {
                    MainViewModel.current = customer;
                    ListRoomWindow roomWindow = new ListRoomWindow();
                    roomWindow.Show();
                    this.Close();
                }    
            }
            else
            {
                MessageBox.Show("Wrong password or username");
            }

        }
    }
}