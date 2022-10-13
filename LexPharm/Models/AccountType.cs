using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.Models
{
    public enum AccountType
    {
        [Description("Admin")]
        Admin = 1,
        [Description("Doctor")]
        Doctor,
        [Description("User")]
        User,
    }
}
