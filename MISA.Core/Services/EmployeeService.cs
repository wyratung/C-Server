using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MISA.Core.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Fields

        IEmployeeRepository _employeeRepository;
        ServiceResult _serviceResult;

        #endregion

        #region Constructors

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Lấy mã nhân viên mới 

        /// <summary>
        /// Lấy mã nv mới
        /// </summary>
        /// <returns>Kết quả nghiệp vụ lấy mã mới</returns>
        /// CreatedBy: NTDUNG (18/08/2021)
        public ServiceResult GetNewCode()
        {
            _serviceResult.Data = _employeeRepository.GetNewCode();
            _serviceResult.IsValid = _serviceResult.Data != null;
            return _serviceResult;
        }

        #endregion

        //#region Phân trang và lọc dữ liệu nhân viên
        ///// <summary>
        ///// Tìm kiếm và phân trang
        ///// </summary>
        ///// <param name="pageSize"></param>
        ///// <param name="pageNumber"></param>
        ///// <param name="filterString"></param>
        ///// <param name="departmentId"></param>
        ///// <param name="positionId"></param>
        ///// <returns> Kết quả nghiệp vụ phân trang và lọc dữ liệu</returns>
        
        //public ServiceResult GetByFilter(int pageSize, int pageNumber, string filterString, Guid? departmentId, Guid? positionId)
        //{
        //    _serviceResult.Data = _employeeRepository.GetByFilter(pageSize, pageNumber, filterString, departmentId, positionId);
        //    _serviceResult.IsValid = _serviceResult.Data != null;
        //    return _serviceResult;
        //}

        //#endregion
    }
}
