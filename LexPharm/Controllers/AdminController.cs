using LexPharm.Models;
using LexPharm.Services;
using LexPharm.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountServices _accountServices;
        private readonly IUserServices _userServices;

        public AdminController(IAccountServices accountServices, IUserServices userServices)
        {
            _accountServices = accountServices;
            _userServices = userServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Doctors()
        {
            var doctors = _accountServices.DoctorsList();
            return View(doctors);
        }

        public IActionResult Users()
        {
            var User = _accountServices.DoctorsList();
            return View(User);
        }

        [HttpGet]
        public IActionResult AddDrug()
        
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddDrug(DrugViewModel obj)
        {


            if (obj != null)
            {
                if(obj.BrandName == null)
                {
                    TempData["error"] = "please put BrandName";
                    return View(obj);
                }

                if(obj.dosage == null)
                {
                    TempData["error"] = "please put Dosage";
                    return View(obj);
                }

                if(obj.ExpiryDate == null)
                {
                    TempData["error"] = "please put ExpiryDate";
                    return View(obj);
                }

                if(obj.Form == null)
                {
                    TempData["error"] = "please put Form";
                    return View(obj);
                }

                if(obj.Generic == null)
                {
                    TempData["error"] = "please put Generic";
                    return View(obj);
                }

                if(obj.ImageUrl == null)
                {
                    TempData["error"] = "please put image";
                    return View(obj);
                }

                var newUpload = _userServices.DrugUpload(obj);
                if (newUpload != null)
                {
                    TempData["success"] = "Success!";
                    return RedirectToAction("DrugStore");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult DrugStore()
        {
            var drugs = _accountServices.DrugList();
            return View(drugs);
        }

        public IActionResult DoctorsRequest()
        {
            
            return View();
        }


        //[HttpPost]
        //public IActionResult DrugStore(DrugViewlModel obj)
        //{
        //    return View();
        //}


    }
}
