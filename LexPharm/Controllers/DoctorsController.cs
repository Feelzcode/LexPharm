using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DrugStore()
        {
            return View();
        }

        public IActionResult RequestAdmmin()
        {
            return View();
        }

        public IActionResult UserQueries()
        {
            return View();
        }
    }
}
