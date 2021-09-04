using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MISA.Core.Interfaces.Services;
using MISA.Core.Entities;
using MISA.Core.Services;
using MISA.Core.Interfaces.Repository;

namespace MISA_Cukcuk_api.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeesController : BaseController<Employee>
    {
        #region Fields

        private readonly IEmployeeService _employeeService;

        #endregion

        #region Constructors

        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        #endregion

        #region Lấy mã nhân viên mới 

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns> Mã code trả về và dữ liệu hoặc mã lỗi của request</returns>
        /// CreatedBy: NTDUNG (17/08/2021)
        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmPloyeeCode()
        {
            try
            {
                _serviceResult = _employeeService.GetNewCode();

                return Ok(_serviceResult);
            }
            catch (Exception e)
            {
                var response = new
                {
                    devMsg = e.Message,
                    userMsg = MISA.Core.Resources.ResourcesVN.MISA_Exception_Error_Msg,
                    errorCode = "MISA_003",
                    traceId = Guid.NewGuid().ToString()
                };
                return StatusCode(500, response);
            }
        }

        #endregion

        //#region Phân trang và lọc dữ liệu nhân viên
        ///// <summary>
        ///// Lọc và phân trang theo tiêu chí tìm kiếm, theo phòng ban, vị trí
        ///// </summary>
        ///// <param name="pageSize"></param>
        ///// <param name="pageNumber"></param>
        ///// <param name="filterString"></param>
        ///// <param name="departmentId"></param>
        ///// <param name="positionId"></param>
        ///// <returns> Mã code trả về và dữ liệu hoặc mã lỗi của request</returns>
        
        //[HttpGet("employeeFilter")]
        //public IActionResult GetEmployeeFilter(int pageSize, int pageNumber,
        //                                        string filterString, Guid? departmentId, Guid? positionId)
        //{
        //    try
        //    {
        //        _serviceResult = _employeeService.GetByFilter(pageSize, pageNumber, filterString, departmentId, positionId);

        //        if (!_serviceResult.IsValid)
        //        {
        //            _serviceResult.Msg = MISA.Core.Resources.ResourcesVN.MISA_Exception_Error_Msg;
        //            return Ok(_serviceResult);
        //        }

        //        // Trả dữ liệu về cho client
        //        return StatusCode(200, _serviceResult.Data);
        //    }
        //    catch (Exception e)
        //    {
        //        var response = new
        //        {
        //            devMsg = e.Message,
        //            userMsg = MISA.Core.Resources.ResourcesVN.MISA_Exception_Error_Msg,
        //            errorCode = "MISA_003",
        //            traceId = Guid.NewGuid().ToString()
        //        };
        //        return StatusCode(500, response);
        //    }
        //}

        //#endregion

    }
}
