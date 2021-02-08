using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.DataLayer.Interfaces
{
    public interface ICustomerDbContext : IDbContext<Customer>
    {
        string CheckCustomerCodeExist(string customerCode);

        string CheckPhoneNumberExist(string phoneNumber);
    }
}