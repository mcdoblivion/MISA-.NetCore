using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Common.Models;
using MISA.Service;
using MISA.Service.Interfaces;

namespace MISA.CukCuk.Api.Controllers
{
    public class CustomersController : BaseController<Customer>
    {
        #region Constructor

        public CustomersController(ICustomerService customerService) : base(customerService)
        {
        }

        #endregion Constructor
    }
}