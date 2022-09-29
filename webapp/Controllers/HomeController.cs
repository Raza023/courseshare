using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapp.Models;
using webapp.Models.Interfaces;
using Microsoft.AspNetCore.Cors;



namespace webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsers userRepo;
        private readonly ICategory categoryRepo;
        private readonly ICourse courseRepo;

        public HomeController(ILogger<HomeController> logger, IUsers iu, ICategory ic, ICourse icr)
        {
            _logger = logger;
            userRepo = iu;
            categoryRepo = ic;
            courseRepo = icr;
        }
        
        public IActionResult Index()
        {
            List<Category> li = new List<Category>();
            //Category c = new Category();
            li = categoryRepo.getCategoriesList();
            return View("Index",li);
        }

        [HttpGet]
        [EnableCors("APICorsPolicy")]
        public IActionResult contactus()
        {
            return View();
        }
        [HttpPost]
        [EnableCors("APICorsPolicy")]
        public IActionResult contactus(string name, string email, string subject, string message)
        {
            //Users u = new Users();
            bool sent = userRepo.SendEmail(name, email, subject, message);
            if(sent)
            {
                return View("contactus","Your message has been sent.");
            }
            else
            {
                return View("contactus","There is an error in sending your message. Please try again!");
            }
        }

        [HttpPost]
        public IActionResult searchresult(string search)
        {
            if((HttpContext.Request.Cookies.ContainsKey("username") && HttpContext.Request.Cookies.ContainsKey("password")) || (HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword")) || (HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword")))  //checking if cookie exists.
            {
                List<Course> li = courseRepo.getSearchedCourses(search);
                return View("searchresult",li);
            }
            else
            {
                ViewBag.lgout = true;
                ViewBag.data = "You must have to login first.";
                List<Category> li = new List<Category>();
                //Category c = new Category();
                li = categoryRepo.getCategoriesList();
                return View("~/Views/Home/Index.cshtml",li);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}