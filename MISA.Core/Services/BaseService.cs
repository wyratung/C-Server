using MISA.Core.Attributes;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MISA.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region Fields

        IBaseRepository<MISAEntity> _repository;
        ServiceResult _serviceResult;

        #endregion

        #region Constructors

        public BaseService(IBaseRepository<MISAEntity> repository)
        {
            _repository = repository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Các phương thức GET

        /// <summary>
        /// Lấy toàn bộ data
        /// </summary>
        /// <returns> Kết quả nghiệp vụ lấy tất cả dữ liệu</returns>
        
        public virtual ServiceResult Get()
        {
            _serviceResult.Data = _repository.Get();
            _serviceResult.IsValid = _serviceResult.Data != null;
            return _serviceResult;
        }

        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <param name="entityId">Id của entity</param>
        /// <returns> Kết quả nghiệp vụ lấy theo id</returns>
        
        public virtual ServiceResult GetById(Guid entityId)
        {
            _serviceResult.Data = _repository.GetById(entityId);
            _serviceResult.IsValid = _serviceResult.Data != null;
            return _serviceResult;
        }

        #endregion

        #region Thêm mới

        /// <summary>
        /// Thêm bản ghi mới vào bảng khách hàng
        /// </summary>
        /// <param name="entity">Dữ liệu thêm mới</param>
        /// <returns>Kết quả nghiệp vụ thêm mới</returns>
        
        public virtual ServiceResult Add(MISAEntity entity)
        {
            // Validate dữ liệu
            var className = typeof(MISAEntity).Name;
            var properties = entity.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var propMISArequired = prop.GetCustomAttributes(typeof(MISARequired), true);
                if (propMISArequired.Length > 0)
                {
                    var propValue = prop.GetValue(entity);
                    var propDisplayName = prop.GetCustomAttributes(typeof(MISADisplayName), true);
                    var propMISAUnique = prop.GetCustomAttributes(typeof(MISAUnique), true);
                    var fieldName = (propDisplayName[0] as MISADisplayName).FieldName;

                    if (propValue == null || propValue.ToString() == "")
                    {
                        _serviceResult.IsValid = false;
                        _serviceResult.Msg = string.Format(ResourcesVN.MISA_Field_Emply_Msg, fieldName);
                        return _serviceResult;
                    }
                    else
                    {
                        if (propMISAUnique.Length > 0)
                        {
                            //var checkDuplicate = _repository.CheckDuplicate(entity,propValue.ToString(), prop.Name);
                            var checkDuplicate = true;
                            if (!checkDuplicate)
                            {
                                _serviceResult.IsValid = false;
                                _serviceResult.Msg = string.Format(ResourcesVN.MISA_Field_Duplicate_Msg, fieldName);
                                return _serviceResult;
                            }
                        }
                    }
                }
            }
            // Kết nối infrastructure service làm việc với db

            _serviceResult.Data = _repository.Add(entity);
            if ((int)_serviceResult.Data > 0)
            {
                _serviceResult.IsValid = true;
            }
            else
            {
                _serviceResult.IsValid = false;
                _serviceResult.Msg = ResourcesVN.MISA_Exception_Error_Msg;
            }
            return _serviceResult;
        }

        #endregion

        #region Cập nhật

        /// <summary>
        /// Cập nhật dữ liệu khách hàng
        /// </summary>
        /// <param name="entity">     Dữ liệu cập nhật</param>
        /// <param name="entityId">   Id của khác hàng</param>
        /// <returns> Kết quả nghiệp vụ chỉnh sửa</returns>
        
        public virtual ServiceResult Update(MISAEntity entity, Guid entityId)
        {
            // Kết nối infrastructure service làm việc với db

            _serviceResult.Data = _repository.Update(entity, entityId);

            if ((int)_serviceResult.Data > 0)
            {
                _serviceResult.IsValid = true;
            }
            else
            {
                _serviceResult.IsValid = false;
                _serviceResult.Msg = ResourcesVN.MISA_Exception_Error_Msg;
            }
            return _serviceResult;
        }

        #endregion

        #region Các phương thức xóa

        /// <summary>
        /// Xóa một bản ghi với id tương ứng
        /// </summary>
        /// <param name="entityId">id của khách hàng cần xóa</param>
        /// <returns> Kết quả nghiệp vụ xoá 1 entity</returns>
        
        public virtual ServiceResult DeleteOne(Guid entityId)
        {
            _serviceResult.Data = _repository.DeleteOne(entityId);
            _serviceResult.IsValid = (int)_serviceResult.Data > 0;

            return _serviceResult;
        }

        /// <summary>
        /// Xóa nhiều khách hàng
        /// </summary>
        /// <param name="entityIds">List id cần xóa</param>
        /// <returns> Kết quả nghiệp vụ xoá nhiều entity</returns>
        
        public virtual ServiceResult DeleteMany(List<Guid> entityIds)
        {
            _serviceResult.Data = _repository.DeleteMany(entityIds);
            _serviceResult.IsValid = (int)_serviceResult.Data > 0;
            return _serviceResult;
        }

        #endregion
    }
}
