using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample_WebApiDependencyInjection.Interfaces;
using Sample_WebApiDependencyInjection.Models;

namespace Sample_WebApiDependencyInjection
{
    public class BusinessService : IBusinessService
    {
        private readonly ICustomerRepository _customerRepository;

        public BusinessService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers() {
            return _customerRepository.GetAll();
        }
    }
}
