using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface ICustomerService : IBaseService<Customer>
    {
        #region Phân trang và lọc dữ liệu khách hàng
        /// <summary>
        /// Lấy và lọc dữ liệu
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="filterString"></param>
        /// <param name="customerGroupId"></param>
        /// <returns> Kết quả nghiệp vụ phân trang và lọc dữ kiệu khách hàng</returns>
        
        ServiceResult GetByFilter(int pageSize, int pageNumber, string filterString, Guid? customerGroupId);

        #endregion

        #region Import dữ liệu khách hàng
        /// <summary>
        /// Import dữ liệu khách hàng vào database
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="cancellationToken"></param>
        /// <returns> Kết quả nghiệp vụ import dữ liệu kháchh hàng</returns>
        
        //ServiceResult ImportData(IFormFile formFile, CancellationToken cancellationToken);

        #endregion
    }
}
