using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        #region Fields

        ICustomerRepository _customerRepository;
        ServiceResult _serviceResult;

        #endregion

        #region Constructors

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Phân trang và lọc dữ liệu khách hàng 

        /// <summary>
        /// Lấy theo chuỗi tìm kiếm hoặc phân trang
        /// </summary>
        /// <param name="pageSize">         Số bản ghi trên 1 trang</param>
        /// <param name="pageNumber">       Chỉ số của trang</param>
        /// <param name="filterString">     chuỗi tìm kiếm</param>
        /// <param name="customerGroupId">  Id của nhóm khách hàng</param>
        /// <returns>Kết quả nghiệp vụ phân trang và lọc dữ liệu</returns>
        
        public ServiceResult GetByFilter(int pageSize, int pageNumber, string filterString, Guid? customerGroupId)
        {
            //_serviceResult.Data = _customerRepository.GetByFilter(pageSize, pageNumber, filterString, customerGroupId);
            _serviceResult.IsValid = _serviceResult.Data != null;
            return _serviceResult;
        }

        #endregion

        #region Import dữ liệu khách hàng
        /// <summary>
        /// Import dữ liệu khách hàng 
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="cancellationToken"></param>
        /// <returns> Kết quả nghiệp vụ import dữ liệu khách hàng</returns>
        //public ServiceResult ImportData(IFormFile formFile, CancellationToken cancellationToken)
        //{
        //    if (formFile == null || formFile.Length <= 0)
        //    {
        //        _serviceResult.IsValid = false;
        //        _serviceResult.Msg = MISA.Core.Resources.ResourcesVN.MISA_Delete_Success_Msg;
        //        return _serviceResult;
        //    }

        //    var customers = new List<Customer>();

        //    using (var stream = new MemoryStream())
        //    {
        //        formFile.CopyToAsync(stream, cancellationToken);

        //        using (var package = new ExcelPackage(stream))
        //        {
        //            ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
        //            var rowCount = workSheet.Dimension.Rows;
        //            var colCount = workSheet.Dimension.Columns;

        //            for (int row = 3; row <= rowCount; row++)
        //            {
        //                /**
        //                 * 1. Mã khách hàng
        //                 * 2. Tên khách hàng
        //                 * 3. Mã thẻ thành viên
        //                 * 4. Nhóm khách hàng
        //                 * 5. Số điện thoại
        //                 * 6. Ngày sinh
        //                 * 7. Tên công ty
        //                 * 8. Mã số thuế
        //                 * 9. Email
        //                 * 10. Địa chỉ
        //                 * 11. Ghi chú
        //                 */
        //                Object[] rowValue = new object[colCount + 1];
        //                for (int col = 1; col <= colCount; col++)
        //                {
        //                    rowValue[col] = workSheet.Cells[row, col].Value;
        //                }
        //                var customer = new Customer
        //                {
        //                    CustomerCode = rowValue[1] == null ? null : rowValue[1].ToString().Trim(),
        //                    FullName = rowValue[2] == null ? null : rowValue[2].ToString().Trim(),
        //                    MemberCardCode = rowValue[3] == null ? null : rowValue[3].ToString().Trim(),
        //                    CustomerGroupName = rowValue[4] == null ? null : rowValue[4].ToString().Trim(),
        //                    PhoneNumber = rowValue[5] == null ? null : rowValue[5].ToString().Trim(),
        //                    CompanyName = rowValue[6] == null ? null : rowValue[6].ToString().Trim(),
        //                    CompanyTaxCode = rowValue[7] == null ? null : rowValue[7].ToString().Trim(),
        //                    Email = rowValue[9] == null ? null : rowValue[9].ToString().Trim()
        //                };
        //                customer.ImportError = ValidateImportData(customer);
        //                customers.Add(customer);
        //            }
        //        }
        //    }
        //    _serviceResult.Data = customers;
        //    return _serviceResult;
        //}

        //public ServiceResult ImportData(Microsoft.AspNetCore.Http.IFormFile formFile, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
    }
}
