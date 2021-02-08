using MISA.Common.Models;
using MISA.Common.Properties;
using MISA.DataLayer;
using MISA.DataLayer.DbContexts;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;

namespace MISA.Service.Services
{
    /// <summary>
    /// Xử lý nghiệp vụ khách hàng
    /// </summary>
    /// CreatedBy: DMCUONG (05/02/2021)
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        #region Declare

        private readonly ICustomerDbContext _dbContext;

        #endregion Declare

        #region Constructor

        public CustomerService(ICustomerDbContext iCustomerDbContext) : base(iCustomerDbContext)
        {
            _dbContext = iCustomerDbContext;
        }

        #endregion Constructor

        #region Method

        protected override bool IsInsertDataValid(Customer customer, ErrorMsg errorMsg = null)
        {
            var isValid = true;
            if (errorMsg == null) errorMsg = new ErrorMsg();

            // Validate dữ liệu (xử lý nghiệp vụ):
            // 1. Validate bắt buộc nhập
            if (string.IsNullOrEmpty(customer.CustomerCode))
            {
                errorMsg.UserMsg.Add(Resources.ErrorService_EmptyCustomerCode);
                isValid = false;
            }

            // 2. Validate dữ liệu không được phép trùng: mã khách hàng, số điện thoại
            // - Kiểm tra trong database tồn tại mã khách hàng chưa
            var customerCodeExist = _dbContext.CheckCustomerCodeExist(customer.CustomerCode);
            if (customerCodeExist != null)
            {
                errorMsg.UserMsg.Add(Resources.ErrorService_DuplicateCustomerCode);
                isValid = false;
            }

            // - Kiểm tra trong database tồn tại số điện thoại chưa
            var phoneNumberExist = _dbContext.CheckPhoneNumberExist(customer.PhoneNumber);
            if (phoneNumberExist != null)
            {
                errorMsg.UserMsg.Add(Resources.ErrorService_DuplicateCustomerPhoneNumber);
                isValid = false;
            }

            // 3. Validate tiếp

            return isValid;
        }

        #endregion Method
    }
}