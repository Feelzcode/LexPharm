using LexPharm.DataBase;
using LexPharm.Models;
using LexPharm.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountServices(UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
        {
            _userManager = userManager;

            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public async Task<ApplicationUser> UserApplicantService(ApplicationUserViewModel applicationUserViewModel)
        {
                string docProfilePictureFilePath = string.Empty;

                if (applicationUserViewModel.ImageUrl != null)
                {
                    docProfilePictureFilePath = UploadedFile(applicationUserViewModel.ImageUrl, "/DoctorProfilePix/");
                }
                var newAppUser = new ApplicationUser();
                {
                    newAppUser.FirstName = applicationUserViewModel.FirstName;
                    newAppUser.LastName = applicationUserViewModel.LastName;
                    newAppUser.Email = applicationUserViewModel.Email;
                    newAppUser.PhoneNumber = applicationUserViewModel.PhoneNumber;
                    newAppUser.UserName = applicationUserViewModel.UserName;
                    newAppUser.Address = applicationUserViewModel.Address;
                    newAppUser.ProfilePicture = docProfilePictureFilePath;
                    newAppUser.MedicalField = applicationUserViewModel.MedicalField;
                    newAppUser.Nationality = applicationUserViewModel.Nationality;
                    newAppUser.Gender = applicationUserViewModel.Gender;
                    newAppUser.Deactivated = false;
                    newAppUser.IsAdmin = false;
                    newAppUser.AccountType = AccountType.User;
                    
                    

                }
                var result = await _userManager.CreateAsync(newAppUser, applicationUserViewModel.Password);
                if (result.Succeeded)
                {
                    return newAppUser;

                }
            return null;
        }

        public async Task<ApplicationUser> DoctorApplicantService(ApplicationUserViewModel applicationUserViewModel)
        {
            string docProfilePictureFilePath = string.Empty;

            if (applicationUserViewModel.ImageUrl != null)
            {
                docProfilePictureFilePath = UploadedFile(applicationUserViewModel.ImageUrl, "/DoctorProfilePix/");
            }
            var newAppUser = new ApplicationUser();
            {
                newAppUser.FirstName = applicationUserViewModel.FirstName;
                newAppUser.LastName = applicationUserViewModel.LastName;
                newAppUser.Email = applicationUserViewModel.Email;
                newAppUser.PhoneNumber = applicationUserViewModel.PhoneNumber;
                newAppUser.UserName = applicationUserViewModel.UserName;
                newAppUser.Address = applicationUserViewModel.Address;
                newAppUser.ProfilePicture = docProfilePictureFilePath;
                newAppUser.MedicalField = applicationUserViewModel.MedicalField;
                newAppUser.Nationality = applicationUserViewModel.Nationality;
                newAppUser.Gender = applicationUserViewModel.Gender;
                newAppUser.Deactivated = false;
                newAppUser.IsAdmin = false;
                newAppUser.AccountType = AccountType.Doctor; 


            }
            var result = await _userManager.CreateAsync(newAppUser, applicationUserViewModel.Password);
            if (result.Succeeded)
            {
                return newAppUser;

            }
            return null;
        }

        public string UploadedFile(IFormFile filesUrl, string fileLocation)
        {
            string uniqueFileName = string.Empty;

            if (filesUrl != null)
            {
                var upPath = fileLocation.Trim('/');
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, upPath);

                string pathString = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", upPath);
                if (!Directory.Exists(pathString))
                {
                    Directory.CreateDirectory(pathString);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + filesUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    filesUrl.CopyTo(fileStream);
                }
            }
            var generatedPictureFilePath = fileLocation + uniqueFileName;
            return generatedPictureFilePath;
        }

        public List<ApplicationUser> DoctorsList()
        {
            var allDoc = _userManager.Users.Where(d => d.AccountType == AccountType.Doctor && d.Deactivated == false).ToList();
            
            return allDoc;
        }
        public List<ApplicationUser> UsersList()
        {
            var allUser = _userManager.Users.Where(u => u.AccountType == AccountType.User).ToList();
            return allUser;
        }

        public List<Drugs> DrugList()
        {
            var allDrugs = _context.Drugs.ToList();

            return allDrugs;
        }

        //public List<Drugs> DrugList()
        //{
        //    var allDrugs = _userManager.Users.Where(d => d.);
        //}
    }
}

