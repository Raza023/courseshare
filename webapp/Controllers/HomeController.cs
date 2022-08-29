using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;

namespace webapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Category> li = new List<Category>();
            Category c = new Category();
            li = c.getCategoriesList();
            return View("Index",li);
        }

        [HttpGet]
        public IActionResult contactus()
        {
            return View();
        }
        [HttpPost]
        public IActionResult contactus(string name, string email, string subject, string message)
        {
            Users u = new Users();
            bool sent = u.SendEmail(name, email, subject, message);
            if(sent)
            {
                return View("contactus","Your message has been sent.");
            }
            else
            {
                return View("contactus","There is an error in sending your message. Please try again!");
            }
        }
    }
}