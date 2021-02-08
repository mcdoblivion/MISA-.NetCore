using System.Linq;
using Dapper;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;

namespace MISA.DataLayer.DbContexts
{
    public class CustomerDbContext : DbContext<Customer>, ICustomerDbContext
    {
        #region Method

        /// <summary>
        /// Kiểm tra mã khách hàng đã tồn tại chưa
        /// </summary>
        /// <param name="customerCode">Mã khách hàng cần kiểm tra</param>
        /// <returns>Mã khách hàng tìm được hoặc null</returns>
        /// CreatedBy: DMCUONG (06/02/2021)
        public string CheckCustomerCodeExist(string customerCode)
        {
            var sql = $"SELECT CustomerCode FROM Customer AS C WHERE C.CustomerCode = '{customerCode}'";
            var customerCodeInDb = _dbConnection.Query<string>(sql).FirstOrDefault();
            return customerCodeInDb;
        }

        /// <summary>
        /// Kiểm tra số điện thoại khách hàng đã tồn tại chưa
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại cần kiểm tra</param>
        /// <returns>Số điện thoại tìm được hoặc null</returns>
        /// CreatedBy: DMCUONG (06/02/2021)
        public string CheckPhoneNumberExist(string phoneNumber)
        {
            var sql = $"SELECT PhoneNumber FROM Customer AS C WHERE C.PhoneNumber = '{phoneNumber}'";
            var customerCodeInDb = _dbConnection.Query<string>(sql).FirstOrDefault();
            return customerCodeInDb;
        }

        #endregion Method
    }
}