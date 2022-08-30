using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using webapp.Models;
using webapp.Models.Interfaces;

namespace webapp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICategory categoryRepo;

        public CourseController(ILogger<CourseController> logger, IUsers iu, ICategory ic)
        {
            _logger = logger;
            categoryRepo = ic;
        }

        [HttpGet]
        public IActionResult Courses()
        {
            List<Category> li = new List<Category>();
            //Category c = new Category();
            li = categoryRepo.getCategoriesList();
            return View("Courses",li);
        }
        [HttpPost]
        public IActionResult Courses(string category)
        {
            List<Category> li = new List<Category>();
            //Category c = new Category();
            li = categoryRepo.getCategoriesData(category);
            return this.Ok(li);
        }

        [HttpPost]
        public IActionResult GetMyViewComponent(string name, string description, string filename, string catpath) {
            return ViewComponent("CategorySummary",new { name=name, description=description, filename=filename, catpath=catpath} );
        }


        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult Development()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}