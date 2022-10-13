using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.Models
{
    public class Drugs
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Generic { get; set; }
        public int ProductNo { get; set; }
        public string drugImages { get; set; }
   
        public string dosage { get; set; }
        public string Form { get; set; }
        public string ExpiryDate { get; set; }
        public string Price { get; set; }
    }
}
