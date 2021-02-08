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
    [Route("api/v1/customer-groups")]
    [ApiController]
    public class CustomerGroupsController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách nhóm khách hàng
        /// </summary>
        /// <returns>Danh sách nhóm khách hàng</returns>
        /// CreatedBy: DMCUONG (06/02/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var customerService = new CustomerGroupService();
            var serviceResult = customerService.GetCustomerGroups();
            var customerGroups = serviceResult.Data as List<CustomerGroup>;

            return StatusCode(customerGroups.Count == 0 ? 204 : 200, serviceResult.Data);
        }
    }
}