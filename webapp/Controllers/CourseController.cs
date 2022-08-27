

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;

namespace webapp.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Courses()
        {
            string myData= "This is courses string.";
            return View("Courses",myData);
        }
        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult contactus()
        {
            return View();
        }
    }
}