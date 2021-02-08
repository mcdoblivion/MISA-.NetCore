using MISA.Common.Models;
using MISA.DataLayer;
using MISA.DataLayer.DbContexts;
using MISA.DataLayer.Interfaces;

namespace MISA.Service.Services
{
    /// <summary>
    /// Xử lý nghiệp vụ nhóm khách hàng
    /// </summary>
    /// CreatedBy: DMCUONG (06/02/2021)
    public class CustomerGroupService : BaseService<CustomerGroup>
    {
        #region Constructor

        public CustomerGroupService(IDbContext<CustomerGroup> iDbContext) : base(iDbContext)
        {
        }

        #endregion Constructor

        #region Method

        protected override bool IsInsertDataValid(CustomerGroup entity, ErrorMsg errorMsg = null)
        {
            return base.IsInsertDataValid(entity, errorMsg);
        }

        #endregion Method
    }
}