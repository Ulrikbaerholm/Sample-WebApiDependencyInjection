using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Sample_WebApiDependencyInjection.Models;
using Sample_WebApiDependencyInjection.Interfaces;
using Microsoft.Extensions.Logging;

namespace Sample_WebApiDependencyInjection.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IBusinessService _businessService;
        private readonly ILogger _logger;
        public CustomersController(IBusinessService businessService, ILogger<CustomersController> logger)
        {
            _businessService = businessService;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            _logger.LogError("This is an exception", new Exception("My App Exception Test"));

            return _businessService.GetAllCustomers();
        }
        
    }
}
