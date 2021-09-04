using MISA.Core.AttributedRequired;
using MISA.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Customer: BaseEntity
    {
        #region Properties

        /// <summary>
        /// Id khách hàng
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [MISARequired]
        [MISAUnique]
        [MISADisplayName("Mã khách hàng")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên đệm
        /// </summary>
        public string FirstName { get; set; }


        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Tên đầy đủ
        /// </summary>
        [MISARequired]
        [MISADisplayName("Tên đầy đủ")]
        public string FullName { get; set; }


        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }


        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }


        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }


        /// <summary>
        /// Địa chỉ email
        /// </summary>
        [MISARequired]
        [MISAEmail]
        [MISADisplayName("Email")]
        public string Email { get; set; }


        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }


        /// <summary>
        /// Id nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }


        /// <summary>
        /// Số tiền nợ
        /// </summary>
        public double? DebitAmount { get; set; }


        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }


        /// <summary>
        /// Mã số thuế công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }


        /// <summary>
        /// Đã ngừng theo dõi hay chưa
        /// </summary>
        public int? IsStopFollow { get; set; }

        /// <summary>
        /// Tên của nhóm khách hàng
        /// </summary>
        [MISANotMap]
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Lỗi xảy ra khi import dữ liệu
        /// </summary>
        [MISANotMap]
        public List<string> ImportError { get; set; }
        #endregion

    }
}
