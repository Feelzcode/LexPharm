using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Cart()
        {
            return View();
        }



        public IActionResult ConsultDoctor()
        {
            return View();
        }


        public IActionResult DoctorsAdvice()
        {
            return View();
        }

        public IActionResult DrugStore()
        {
            return View();
        }
    }
}
