using LaytonTemple.Models;
using LaytonTemple.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LaytonTemple.Controllers
{
    public class HomeController : Controller
    {
        private ApptContext daContext { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApptContext group)
        {
            daContext = group;
        } 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointments() // shows list of all made appointments 
        {
            return View(daContext.Groups);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Sign_Up()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Sign_Up(AvailableTimes temp)
        {
            var x = new GroupView { Timeslot = temp };
            return View("Form", x);
        }


        [HttpPost]
        public IActionResult Form(GroupView group)
        {
            daContext.Update(group);
            daContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
