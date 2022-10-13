using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MedicalField { get; set; }
        public bool Deactivated { get; set; }
        public bool IsAdmin { get; set; }
        public string Nationality { get; set; }
        public EnumClass Gender { get; set; }
        public string ProfilePicture { get; set; }
        public AccountType AccountType { get; set; }
    }
}
