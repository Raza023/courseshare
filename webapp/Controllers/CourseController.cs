

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
            List<Category> li = new List<Category>();
            Category c = new Category();
            li = c.getCategoriesList();
            return View("Courses",li);
        }
        public IActionResult Categories()
        {
            return View();
        }
    }
}