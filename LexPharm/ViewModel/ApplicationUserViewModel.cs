using LexPharm.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.ViewModel
{
    public class ApplicationUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MedicalField { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        
        public string ProfilePicture { get; set; }
        [NotMapped]
        public IFormFile ImageUrl { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool Deactivated { get; set; }
        public bool IsAdmin { get; set; }
        public EnumClass Gender { get; set; }

       






    }
}
