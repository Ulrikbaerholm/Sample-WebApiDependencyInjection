using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample_WebApiDependencyInjection.Interfaces;
using Sample_WebApiDependencyInjection.Models;

namespace Sample_WebApiDependencyInjection.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAll() {
            List<Customer> customers = new List<Customer>();

            customers.Add(
                    new Customer { Id = 1, Name = "Customer A" }
                );

            customers.Add(
                    new Customer { Id = 2, Name = "Customer B" }
                );

            customers.Add(
                    new Customer { Id = 3, Name = "Customer C" }
                );

            customers.Add(
                    new Customer { Id = 4, Name = "Customer D" }
                );

            customers.Add(
                    new Customer { Id = 5, Name = "Customer E" }
                );

            return customers;
        }
    }
}
