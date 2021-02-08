using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            Success = true;
        }

        /// <summary>
        /// Trạng thái service: true - thành công, false - thất bại
        /// </summary>
        public bool Success { get; set; }

        public object Data { get; set; }

        public string MISACode { get; set; }
    }
}