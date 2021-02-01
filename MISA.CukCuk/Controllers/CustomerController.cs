using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using MISA.CukCuk.Models;

namespace MISA.CukCuk.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var c1 = new Customer
            {
                CustomerCode = "1",
                CustomerName = "C1"
            };

            var customers = new List<Customer>
            {
                c1
            };

            return Ok(customers);
        }
    }
}