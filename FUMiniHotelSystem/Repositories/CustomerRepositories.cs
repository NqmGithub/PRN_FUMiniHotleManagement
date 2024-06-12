using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepositories : ICustomerRepositories
    {
        private readonly FuminiHotelManagementContext _context;

        public CustomerRepositories()
        {
            _context = new FuminiHotelManagementContext();
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var cus = _context.Customers.Find(id);
            if (cus != null)
            {
                _context.Customers.Remove(cus);
                _context.SaveChanges();
            }
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public Customer GetByNamePassword(string name, string pass)
        {
            return _context.Customers.ToList().FirstOrDefault(c => c.CustomerFullName == name && c.Password == pass);
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}
