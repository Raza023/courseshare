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
        private readonly ICourse courseRepo;

        public CourseController(ILogger<CourseController> logger, IUsers iu, ICategory ic, ICourse icr)
        {
            _logger = logger;
            categoryRepo = ic;
            courseRepo = icr;
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
            List<Course> li = courseRepo.getDevCourses();
            return View("Development",li);
        }

        public IActionResult PhotographyAndVideo()
        {
            return View();
        }

        public IActionResult TeachingAndAcademic()
        {
            return View();
        }

        public IActionResult Design()
        {
            return View();
        }

        public IActionResult HealthAndFitness()
        {
            return View();
        }

        public IActionResult Business()
        {
            return View();
        }

        public IActionResult details(int id)     //must use id here.
        {
            List<Video> li = courseRepo.getCourseVideos(id);
            return View("details",li);
        }

        public IActionResult videodetails(int id)     //must use id here.
        {
            Video v = courseRepo.getCourseVideo(id);
            return View("videodetails",v);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}