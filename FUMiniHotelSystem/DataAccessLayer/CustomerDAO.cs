using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        private readonly FuminiHotelManagementContext _context;

        public CustomerDAO(FuminiHotelManagementContext context)
        {
            _context = context;
        }
        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
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
    }
}
