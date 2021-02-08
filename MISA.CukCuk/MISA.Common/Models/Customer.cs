using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    /// CreatedBy: DMCUONG (05/02/2021)
    public class Customer
    {
        #region Properties

        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ tên khách hàng
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Mã thẻ thành viên của khách hàng
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Ngày sinh khách hàng
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính khách hàng
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Email khách hàng
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại khách hàng
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Tên công ty của khách hàng
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế khách hàng
        /// </summary>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string Address { get; set; }

        #endregion Properties

        #region Orther

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }

        #endregion Orther
    }
}