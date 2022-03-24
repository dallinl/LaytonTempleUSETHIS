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
            //I think this may be where the issue is. In the videos there is a "var applications = daContext.Responses" and then the return is "return View(applications)"
            return View(daContext.Groups);
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

        [HttpGet]
        public IActionResult Edit(int groupid)
        {
            var application = daContext.Groups.Single(x => x.GroupID == groupid);



            return View("Form", application);
        }

        [HttpPost]
        public IActionResult Edit(GroupInfo blah)
        {
            daContext.Update(blah);
            daContext.SaveChanges();


            //This may need to be a redirect to action
            return View("Appointments");
        }

        public IActionResult Delete(GroupInfo blah)
        {
            daContext.Groups.Remove(blah);
            daContext.SaveChanges();


            return View("Appointments");
        }

    }
}
