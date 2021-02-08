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
    [Route("api/v1/customer-groups")]
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {
        #region Constructor

        public CustomerGroupsController(IBaseService<CustomerGroup> baseService) : base(baseService)
        {
        }

        #endregion Constructor
    }
}