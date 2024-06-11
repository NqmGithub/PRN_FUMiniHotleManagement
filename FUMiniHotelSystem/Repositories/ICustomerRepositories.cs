using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories
{
    public interface ICustomerRepositories
    {
        List<Customer> GetCustomers();

        Customer GetCustomerById(int id);

        void UpdateCustomer(Customer customer);

        void DeleteCustomer(int id);

        void AddCustomer(Customer customer);

        Customer GetByNamePassword(string name, string pass);
    }
}
