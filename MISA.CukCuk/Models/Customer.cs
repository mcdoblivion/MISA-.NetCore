using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MISA.CukCuk.Models
{
    public class Customer
    {
        #region Property

        public Guid CustomerId { get; set; }

        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        #endregion Property
    }
}