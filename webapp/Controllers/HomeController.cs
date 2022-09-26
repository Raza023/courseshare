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

        public HomeController(ILogger<HomeController> logger, IUsers iu, ICategory ic)
        {
            _logger = logger;
            userRepo = iu;
            categoryRepo = ic;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}