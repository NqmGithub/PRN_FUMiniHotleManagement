using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService
    {
        private readonly ICustomerRepositories _repository;
        public CustomerService()
        {
            _repository = new CustomerRepositories();
        }

        public List<Customer> GetAll()
        {
            return _repository.GetCustomers();
        }

        public Customer Get(int id)
        {
            return _repository.GetCustomerById(id);
        }

        public Customer GetByNamePassword(string name, string pass)
        {
            return _repository.GetByNamePassword(name, pass);
        }

        public void Update(Customer customer)
        {
            _repository.UpdateCustomer(customer);
        }

        public void Delete(int id)
        {
            _repository.DeleteCustomer(id);
        }

        public void Add(Customer customer)
        {
            _repository.AddCustomer(customer);
        }
    }
}
