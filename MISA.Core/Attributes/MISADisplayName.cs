using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISADisplayName : Attribute
    {
        #region Constructor
        public MISADisplayName(string name)
        {
            FieldName = name;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Tên của trường dữ liệu
        /// </summary>
        public string FieldName { get; set; }
        #endregion
    }
}
