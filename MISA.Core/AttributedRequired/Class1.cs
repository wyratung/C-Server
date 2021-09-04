using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.AttributedRequired
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class AttributeRequired : Attribute
    {
    }
}
