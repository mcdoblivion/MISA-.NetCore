using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.DataLayer.Interfaces
{
    public interface ICustomerDbContext : IDbContext<Customer>
    {
        /// <summary>
        /// Kiểm tra mã khách hàng đã tồn tại chưa
        /// </summary>
        /// <param name="customerCode">Mã khách hàng cần kiểm tra</param>
        /// <returns>Mã khách hàng tìm được hoặc null</returns>
        string CheckCustomerCodeExist(string customerCode);

        /// <summary>
        /// Kiểm tra số điện thoại khách hàng đã tồn tại chưa
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại cần kiểm tra</param>
        /// <returns>Số điện thoại tìm được hoặc null</returns>
        string CheckCustomerPhoneNumberExist(string phoneNumber);

        /// <summary>
        /// Kiểm tra email khách hàng tồn tại chưa
        /// </summary>
        /// <param name="email">Email cần kiểm tra</param>
        /// <returns>Email tìm được hoặc null</returns>
        string CheckCustomerEmailExist(string email);
    }
}