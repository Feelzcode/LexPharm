using LexPharm.DataBase;
using LexPharm.Models;
using LexPharm.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountServices _accountServices;
        private readonly ApplicationDbContext _context;


        public UserServices(UserManager<ApplicationUser> userManager, IAccountServices accountServices, ApplicationDbContext context)
        {
            _userManager = userManager;
            _accountServices = accountServices;
            _context = context;
        }

        public async Task<ApplicationUser> FindByPhoneNumberAsync(string phoneNumber)
        {
            return await _userManager.Users.Where(s => s.PhoneNumber == phoneNumber)?.FirstOrDefaultAsync();
        }
        public List<DropdownEnumModel> GetDropDownEnumsList()
        {
            var common = new DropdownEnumModel()
            {
                Id = 0,
                Name = "-- Select --"

            };
            var enumList = ((EnumClass[])Enum.GetValues(typeof(EnumClass))).Select(c => new DropdownEnumModel() { Id = (int)c, Name = c.ToString() }).ToList();
            enumList.Insert(0, common);
            return enumList;
        }
        
        public Drugs DrugUpload(DrugViewModel drugmodel)
        {
            if(drugmodel != null)
            {
                string DrugImageFilePath = string.Empty;

                if (drugmodel.ImageUrl != null)
                {
                    DrugImageFilePath = _accountServices.UploadedFile(drugmodel.ImageUrl, "/DrugProfilePix/");
                }
                var newDrug = new Drugs()
                {
                    BrandName = drugmodel.BrandName,
                    dosage = drugmodel.dosage,
                    ExpiryDate = drugmodel.ExpiryDate,
                    Form = drugmodel.Form,
                    Generic = drugmodel.Generic,
                    drugImages = DrugImageFilePath,
                    ProductNo = drugmodel.ProductNo,
                    Price = drugmodel.Price,
                };
                var result = _context.Drugs.Add(newDrug);
                _context.SaveChanges();              

                if (result != null)
                {
                    return newDrug;
                }
             }
            return null;
        }

        
    }
}
