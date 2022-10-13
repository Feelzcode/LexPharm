using LexPharm.DataBase;
using LexPharm.Models;
using LexPharm.Services;
using LexPharm.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.Controllers
{
    public class AccountController : Controller

    {
       
      
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserServices _UserServices;
        private readonly IAccountServices _accountServices;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserServices userServices, IAccountServices accountServices, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _UserServices = userServices;
            _accountServices = accountServices;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel obj)
        {
            if(obj != null)
            {
                if(obj.UserName == null)
                {
                    TempData["errors"] = "please input username";
                    return View(obj);
                }
                if (obj.Password == null)
                {
                    TempData["error"] = "Please put password";
                    return View(obj);
                }

                var existing = _userManager.Users.Where(u => u.UserName == obj.UserName).FirstOrDefault();
                if (existing != null && !existing.Deactivated)
                {
                    var PasswordSigin = _signInManager.PasswordSignInAsync(obj.UserName, obj.Password, true, false).Result;
                    if (PasswordSigin.Succeeded)
                    {
                        var checkAuth = User.Identity.IsAuthenticated;
                        if(existing.AccountType == AccountType.Admin)
                        {
                            TempData["success"] = "Successfully!";
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (existing.AccountType == AccountType.Doctor)
                        {
                            TempData["success"] = "Successfully!";
                            return RedirectToAction("Index", "Doctors");
                        }
                        else
                        {
                            TempData["success"] = "Successfully!";
                            return RedirectToAction("Index", "User");
                        }
                    }
                }
                else
                {
                    TempData["error"] = "Username does not Exist!";
                    return View();
                } 
            }
            TempData["error"] = "Login was Failed!";
            return View(obj);
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
             ViewBag.gender = _UserServices.GetDropDownEnumsList();
            
            return View();
        }
       
        //Register
        [HttpPost]
        public  IActionResult RegisterUser(ApplicationUserViewModel obj)
        {

            ViewBag.gender = _UserServices.GetDropDownEnumsList();

            if (obj != null)
            {
              
                if (obj.FirstName == null)
                {
                    TempData["error"] = "Please put your FirstName";
                    return View(obj);
                    
                }
                if (obj.LastName == null)
                {
                    TempData["error"] = "Please put your LastName";
                    return View(obj);
                }

                if (obj.Address == null)
                {
                    return View(obj);
                }

                if (obj.PhoneNumber == null)
                {
                    TempData["error"] = "Please put your PhoneNumber";
                    return View(obj);
                }

                if (obj.Nationality == null)
                {
                    TempData["error"] = "Please put your Nationality";
                    return View(obj);
                }

                if (obj.Gender == null)
                {
                    TempData["error"] = "Please put your Gender";
                    return View(obj);
                }

                if (obj.Password == null)
                {
                    TempData["error"] = "Please put your Password ";
                    return View(obj);
                }

                if (obj.ConfirmPassword == null)
                {
                    TempData["error"] = "Please put your ConfirmPassword ";
                    return View(obj);
                }
                if (obj.Email == null)
                {
                    TempData["error"] = "Please put your Email ";
                    return View(obj);
                }
                var checkEmail = _userManager.FindByEmailAsync(obj.Email).Result;
                if (checkEmail != null)
                {
                    TempData["error"] = "Email already exist";

                    return View(obj);
                }
                if (obj.UserName == null)
                {
                    TempData["error"] = "Please put your UserName";
                    return View(obj);
                }
                if (obj.Password != obj.ConfirmPassword)
                {
                    TempData["error"] = "Password does not match";
                    return View(obj);
                }
                //var emailCheck =  _userManager.FindByEmailAsync(obj.Email).Result;
                var PhoneNumber =  _UserServices.FindByPhoneNumberAsync(obj.PhoneNumber).Result;
               
                if (PhoneNumber != null)
                {
                    TempData["error"] = "PhoneNumber already exist";
                    return View(obj);
                }


                var newUser = _accountServices.UserApplicantService(obj).Result;
                if(newUser != null)
                {
                    TempData["success"] = "Success!";
                    return RedirectToAction("Login");
                }
                
            }
            TempData["error"] = "Registration failed";
            return View(obj);
        }

        //AdminRegister
        [HttpGet]
        public IActionResult RegisterDoctor()
        {

            ViewBag.gender = _UserServices.GetDropDownEnumsList();
            return View();
        }

        [HttpPost]
        public IActionResult RegisterDoctor(ApplicationUserViewModel obj)
        {
            ViewBag.gender = _UserServices.GetDropDownEnumsList();
            if (obj != null)
            {

                if (obj.FirstName == null)
                {
                    TempData["error"] = "Please put your FirstName";
                    return View(obj);

                }
                if (obj.LastName == null)
                {
                    TempData["error"] = "Please put your LastName";
                    return View(obj);
                }

                if (obj.Address == null)
                {
                    return View(obj);
                }

                if (obj.MedicalField == null)
                {
                    TempData["error"] = "Please put your MedicalField";
                    return View(obj);
                }

                if (obj.PhoneNumber == null)
                {
                    TempData["error"] = "Please put your PhoneNumber";
                    return View(obj);
                }

                if (obj.Nationality == null)
                {
                    TempData["error"] = "Please put your Nationality";
                    return View(obj);
                }

                if (obj.Gender == null)
                {
                    TempData["error"] = "Please put your Gender";
                    return View(obj);
                }
               

                if (obj.ImageUrl == null)
                {
                    TempData["error"] = "Please put your ImageUrl";
                    return View(obj);
                }

                if (obj.Password == null)
                {
                    TempData["error"] = "Please put your Password ";
                    return View(obj);
                }

                if (obj.ConfirmPassword == null)
                {
                    TempData["error"] = "Please put your ConfirmPassword ";
                    return View(obj);
                }

                if (obj.Email == null)
                {
                    TempData["error"] = "Please put your Email ";
                    return View(obj);
                }

                var checkEmail = _userManager.FindByEmailAsync(obj.Email).Result;
                if (checkEmail != null)
                {
                    TempData["error"] = "Email already exist";

                    return View(obj);
                }
                if (obj.UserName == null)
                {
                    return View(new { isError = true, msg = "Please put your UserName" });
                }
                if (obj.Password != obj.ConfirmPassword)
                {
                    TempData["error"] = "Password does not match";
                    return View(obj);
                }

                var PhoneNumber = _UserServices.FindByPhoneNumberAsync(obj.PhoneNumber).Result;
               
                if (PhoneNumber != null)
                {
                    TempData["error"] = "PhoneNumber already exist";
                    return View(obj);
                }


                var newUser = _accountServices.DoctorApplicantService(obj).Result;
                if (newUser != null)
                {
                    TempData["success"] = "Success!";
                    return View();
                }

            }
            TempData["error"] = "Registration failed";
            return View(obj);
        }

        


      

    }






}

