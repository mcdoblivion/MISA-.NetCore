using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;
using MISA.Common.Properties;
using MISA.DataLayer;

namespace MISA.Service
{
    /// <summary>
    /// Xử lý nghiệp vụ khách hàng
    /// </summary>
    /// CreatedBy: DMCUONG (05/02/2021)
    public class CustomerService
    {
        #region Declare

        private readonly DbContext _dbContext;

        #endregion Declare

        #region Constructor

        public CustomerService()
        {
            _dbContext = new DbContext();
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>ServiceResult</returns>
        public ServiceResult GetCustomers()
        {
            var serviceResult = new ServiceResult()
            {
                Data = _dbContext.GetData<Customer>()
            };
            return serviceResult;
        }

        /// <summary>
        /// Thêm khách hàng
        /// </summary>
        /// <param name="customer">Thực thể khách hàng</param>
        /// <returns>Service Result</returns>
        public ServiceResult InsertCustomer(Customer customer)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            // Validate dữ liệu (xử lý nghiệp vụ):
            // 1. Validate bắt buộc nhập
            if (string.IsNullOrEmpty(customer.CustomerCode))
            {
                errorMsg.UserMsg = Resources.ErrorService_EmptyCustomerCode;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            // 2. Validate dữ liệu không được phép trùng: mã khách hàng, số điện thoại
            // - Kiểm tra trong database tồn tại mã khách hàng chưa
            var customerCodeExist = _dbContext.CheckCustomerCodeExist(customer.CustomerCode);
            if (customerCodeExist != null)
            {
                errorMsg.UserMsg = Resources.ErrorService_DuplicateCustomerCode;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            // - Kiểm tra trong database tồn tại số điện thoại chưa
            var phoneNumberExist = _dbContext.CheckPhoneNumberExist(customer.PhoneNumber);
            if (phoneNumberExist != null)
            {
                errorMsg.UserMsg = Resources.ErrorService_DuplicateCustomerPhoneNumber;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            // 3. Validate tiếp

            // Validate thành công thì thực hiện thêm mới:
            var response = _dbContext.InsertObject(customer);

            serviceResult.Data = response;

            return serviceResult;
        }

        #endregion Method
    }
}