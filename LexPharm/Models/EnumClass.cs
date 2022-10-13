using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.Models
{
    public enum EnumClass
    {
        [Description("Male")]
        Male = 1,
        [Description("Female")]
        Female,
    }
}
