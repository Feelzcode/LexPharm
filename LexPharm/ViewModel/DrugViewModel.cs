using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.ViewModel
{
    public class DrugViewModel
    {
        public string BrandName { get; set; }
        public string Generic { get; set; }
        public int ProductNo { get; set; }
        public string drugImages { get; set; }
        
        public IFormFile ImageUrl { get; set; }
        public string dosage { get; set; }
        public string Form { get; set; }
        public string ExpiryDate { get; set; }
        public string Price { get; set; }
    }
}
