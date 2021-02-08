using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;
using MISA.DataLayer;

namespace MISA.Service
{
    /// <summary>
    /// Xử lý nghiệp vụ nhóm khách hàng
    /// </summary>
    /// CreatedBy: DMCUONG (06/02/2021)
    public class CustomerGroupService
    {
        #region Declare

        private readonly DbContext _dbContext;

        #endregion Declare

        #region Constructor

        public CustomerGroupService()
        {
            _dbContext = new DbContext();
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// Lấy toàn bộ danh sách nhóm khách hàng
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// CreaatedBy: DMCUONG (06/02/2021)
        public ServiceResult GetCustomerGroups()
        {
            var serviceResult = new ServiceResult
            {
                Data = _dbContext.GetData<CustomerGroup>()
            };
            return serviceResult;
        }

        #endregion Method
    }
}