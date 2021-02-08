using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;

namespace MISA.Service.Services
{
    public class CustomerServiceV2 : BaseService<Customer>, ICustomerService
    {
        #region Constructor

        public CustomerServiceV2(IDbContext<Customer> iDbContext) : base(iDbContext)
        {
        }

        #endregion Constructor

        #region Method

        protected override bool IsInsertDataValid(Customer entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
    }

    #endregion Method
}