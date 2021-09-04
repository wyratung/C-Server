using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Responses;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    //public class EmployeeRepository : IEmployeeRepository
    //{
    //    public int Add(Employee employee)
    //    {            
    //        //Mã không đc trùng 
    //        employee.EmployeeId = Guid.NewGuid();
//    var connectionString = "Host = 47.241.69.179;" +
//        "Database=MISA.CukCuk_Demo_NVMANH;" +
//            "User Id = dev;" +
//"Password = 12345678";
    //        //Khởi tạo đối tượng kết nối với  database:
    //        IDbConnection dbConnection = new MySqlConnection(connectionString);
    //        //Khai báo DynamicsParam
    //        var dynamicParam = new DynamicParameters();
    //        //Thêm dữ liệu vào Database
    //        var columnsName = string.Empty;
    //        var columnsParam = string.Empty;
    //        //Đọc từng property của Object
    //        var properties = employee.GetType().GetProperties();
    //        //Duyệt từng property
    //        foreach (var prop in properties)
    //        {
    //            //Lấy tên của prop
    //            var propName = prop.Name;
    //            //Lấy value của prop
    //            var propValue = prop.GetValue(employee);
    //            //Lấy Type
    //            var propType = prop.PropertyType;
    //            //Thêm param tương ứng vs mỗi propperty của đối tượng
    //            dynamicParam.Add($"@{propName}", propValue);
    //            columnsName += $"@{propName},";
    //            columnsParam += $"@{propName},";
    //        }
    //        columnsName = columnsName.Remove(columnsName.Length - 1, 1);
    //        columnsParam = columnsParam.Remove(columnsParam.Length - 1, 1);
    //        var sqlCommand = $"INSERT INTO Employee({columnsName}) VALUE({columnsParam})";
    //        var rowChange = dbConnection.Execute(sqlCommand, param: dynamicParam);
    //        return rowChange;
    //    }

    //    public int Delete(Guid employeeId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Employee> Get()
    //    {
    //        //Truy cập vào database
    //        //Khai báo thong tin kết nối database   
    //        var connectionString = "Host = 47.241.69.179;" +
    //            "Database=MISA.CukCuk_Demo_NVMANH;" +
    //            "User Id=dev;" +
    //            "Password=12345678";
    //        //Khởi tạo đối tượng kết nối với  database:
    //        IDbConnection dbConnection = new MySqlConnection(connectionString);
    //        //Lâý dữ liêụ
    //        var sqlCommand = "SELECT* FROM Employee";
    //        var employees = dbConnection.Query<Employee>(sqlCommand);
    //        return employees.ToList();
    //    }

    //    public Employee GetById(Guid employeeId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int Update(Employee employee, Guid employeeId)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
        {
            //#region Các phương thức GET của riêng Employee

            /// <summary>
            /// Lọc dữ liệu theo chuỗi tìm kiếm hoặc nhóm nv, kết hợp phân trang    
            /// </summary>
            /// <param name="pageSize">         số bản ghi 1 trang</param>
            /// <param name="pageNumber">       chỉ số trang</param>
            /// <param name="filterString">     chuỗi tìm kiếm</param>
            /// <param name="employeeGroupId">  id nhóm nv</param>
            /// <returns></returns>
            //public FilterResponse GetByFilter(int pageSize, int pageNumber, string filterString, Guid? departmentId, Guid? positionId)
            //{
            //    var sqlSelectCount = "SELECT COUNT(*) FROM Employee e ";

            //    var sqlQuery = $"SELECT e.*, d.DepartmentName, p.PositionName, CASE " +
            //                        $"WHEN e.Gender = 0 THEN 'Nữ' " +
            //                        $"WHEN e.Gender = 1 THEN 'Nam' " +
            //                        $"ELSE 'Không xác định' " +
            //                        $"END as GenderName " +
            //                    $"FROM Employee e LEFT JOIN Department d ON d.DepartmentId=e.DepartmentId " +
            //                    $"LEFT JOIN Position p ON p.PositionId=e.PositionId ";
            //    var parameters = new DynamicParameters();

            //    parameters.Add("@pageSize", pageSize);
            //    parameters.Add("@pageStart", pageNumber * pageSize);

            //    if (filterString == null) filterString = "";
            //    var sqlWhere = "WHERE ( UPPER(e.FullName) LIKE CONCAT('%',@filter,'%') " +
            //                "OR UPPER(e.EmployeeCode) LIKE CONCAT('%',@filter,'%') " +
            //                "OR e.PhoneNumber LIKE CONCAT('%',@filter,'%') ) ";

            //    parameters.Add("@filter", filterString.ToUpper());

            //    // Lọc theo id phòng ban và vị trí
            //    if (departmentId != null)
            //    {
            //        sqlWhere += "AND e.DepartmentId=@departmentId ";
            //        parameters.Add("@departmentId", departmentId);
            //    }
            //    if (positionId != null)
            //    {
            //        sqlWhere += "AND e.PositionId=@positionId ";
            //        parameters.Add("@positionId", positionId);
            //    }

            //    sqlQuery += sqlWhere;
            //    sqlSelectCount += sqlWhere;

            //    // Sắp xếp theo chiều giảm dần mã nv
            //    sqlQuery += "ORDER BY e.EmployeeCode DESC ";

            //    // Phân trang cho kết quả truy vấn
            //    sqlQuery += (pageSize > 0) ? "LIMIT @pageStart, @pageSize;" : "";
            //    sqlSelectCount += "ORDER BY e.EmployeeId";

            //    // Thực hiện truy vấn lấy dữ liệu
            //    var employees = _dbConnection.Query<object>(sqlQuery, param: parameters);

            //    if (employees == null)
            //    {
            //        return new FilterResponse
            //        {
            //            TotalRecord = 0,
            //            TotalPage = 0,
            //            Data = null
            //        };
            //    }

            //    var totalRecord = _dbConnection.QueryFirstOrDefault<int>(sqlSelectCount, param: parameters);
            //    var totalPage = (int)(totalRecord / pageSize) + ((totalRecord % pageSize != 0) ? 1 : 0);

            //    return new FilterResponse
            //    {
            //        TotalRecord = totalRecord,
            //        TotalPage = totalPage,
            //        Data = (List<object>)employees
            //    };
            //}

        

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns></returns>
        public string GetNewCode()
            {
                var sqlQuery = "SELECT e.EmployeeCode FROM Employee e ORDER BY e.EmployeeCode DESC LIMIT 1";
                var employeeCode = _dbConnection.QueryFirstOrDefault<string>(sqlQuery);
                int employeeNumber;
                string newEmployeeCode;

                if (employeeCode != null)
                {
                    employeeNumber = int.Parse(employeeCode.Split("NV")[1]);
                    employeeNumber++;
                    newEmployeeCode = $"NV{employeeNumber.ToString().PadLeft(5, '0')}";
                }
                else
                {
                    newEmployeeCode = "NV00001";
                }

                return newEmployeeCode;
            }

            //#endregion
        }
    }
