using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample_WebApiDependencyInjection.Models;

namespace Sample_WebApiDependencyInjection.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
    }
}
