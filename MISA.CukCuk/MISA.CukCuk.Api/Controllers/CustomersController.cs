using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Common.Models;
using MISA.Service;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: DMCUONG (06/02/2021)
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customerService = new CustomerService();
            var serviceResult = customerService.GetCustomers();
            var customers = serviceResult.Data as List<Customer>;
            return StatusCode(customers.Count == 0 ? 204 : 200, customers);
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thực thể khách hàng</param>
        /// <returns>Response tương ứng cho client(201, 400, ...)</returns>
        /// CreatedBy: DMCUONG (06/02/2021)
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            var customerService = new CustomerService();
            var response = customerService.InsertCustomer(customer);
            return StatusCode(!response.Success ? 400 : (int)response.Data > 0 ? 201 : 200, response.Data);
        }
    }
}