using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using webapp.Models;
using webapp.Models.Interfaces;
using Microsoft.AspNetCore.Cors;
using webapp.Models.ViewModels;
using AutoMapper;                        //must have to add this line

namespace webapp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsers userRepo;
        private readonly ICategory categoryRepo;
        private readonly ISeller sellerRepo;
        private readonly ICourse courseRepo;
        private readonly  IMapper imap;

        public AdminController(ILogger<HomeController> logger, IUsers iu, ICategory ic, ISeller isr, ICourse cr, IMapper im)
        {
            _logger = logger;
            userRepo = iu;
            categoryRepo = ic;
            sellerRepo = isr;
            courseRepo = cr;
            imap = im;
        }
        
        public IActionResult Index()
        {
            if(HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword"))
            {
                ViewBag.totalCourses = courseRepo.getCourseCount();
                ViewBag.approvedCourses = courseRepo.getApprovedCourseCount();
                ViewBag.pendingCourses = courseRepo.getPendingCourseCount();

                ViewBag.totalSellers = courseRepo.getSellerCount();
                ViewBag.approvedSellers = courseRepo.getApprovedSellerCount();
                ViewBag.pendingSellers = courseRepo.getPendingSellerCount();

                ViewBag.totalBuyers = courseRepo.getBuyerCount();
                return View("adminhome");
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult login(string username, string password)
        {
            if(username == "adminbhai" && password == "adminbhai")
            {
                if(HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword"))  //checking if cookie exists.
                {
                    //updating cookie
                    HttpContext.Response.Cookies.Delete("ausername");
                    HttpContext.Response.Cookies.Delete("apassowrd");
                    CookieOptions option = new CookieOptions();           //for it add using Microsoft.AspNetCore.Http;
                    option.Expires = System.DateTime.Now.AddDays(10);     //Now cookie will expire after a day. if you want cookies to be saved after closing browser as well.
                    HttpContext.Response.Cookies.Append("ausername", username, option);
                    HttpContext.Response.Cookies.Append("apassword", password, option);
                }
                else
                {
                    //defining cookie
                    CookieOptions option = new CookieOptions();           //for it add using Microsoft.AspNetCore.Http;
                    option.Expires = System.DateTime.Now.AddDays(10);     //Now cookie will expire after a day. if you want cookies to be saved after closing browser as well.
                    HttpContext.Response.Cookies.Append("ausername", username, option);
                    HttpContext.Response.Cookies.Append("apassword", password, option);
                }
                ViewBag.totalCourses = courseRepo.getCourseCount();
                ViewBag.approvedCourses = courseRepo.getApprovedCourseCount();
                ViewBag.pendingCourses = courseRepo.getPendingCourseCount();

                ViewBag.totalSellers = courseRepo.getSellerCount();
                ViewBag.approvedSellers = courseRepo.getApprovedSellerCount();
                ViewBag.pendingSellers = courseRepo.getPendingSellerCount();

                ViewBag.totalBuyers = courseRepo.getBuyerCount();
                return View("adminhome");
            }
            else
            {
                return View("Index","Email or Password is incorrect.");
            }   
        }

        public IActionResult Remove()
        {
            //removing cookie
            HttpContext.Response.Cookies.Delete("ausername");
            return View("Index");
        }

        public IActionResult courseDetails()
        {
            if(HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword"))  //checking if cookie exists.
            {
                return View();
            }
            else
            {
                return View("Index","You must have to login first.");
            }
        }

        public IActionResult approvedcourses()
        {
            if(HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword"))  //checking if cookie exists.
            {
                List<Course> li = courseRepo.getApprovedCourses();
                return View("approvedcourses",li);
            }
            else
            {
                return View("Index","You must have to login first.");
            }
            
        }

        public IActionResult pendingcourses()
        {
            if(HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword"))  //checking if cookie exists.
            {
                List<Course> li = courseRepo.getPendingCourses();
                return View("pendingcourses",li);
            }
            else
            {
                return View("Index","You must have to login first.");
            }
            
        }

        public IActionResult approvedsellers()
        {
            if(HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword"))  //checking if cookie exists.
            {
                List<Seller> li = courseRepo.getApprovedSellers();
                return View("approvedsellers",li);
            }
            else
            {
                return View("Index","You must have to login first.");
            }
            
        }

        public IActionResult pendingsellers()
        {
            if(HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword"))  //checking if cookie exists.
            {
                List<Seller> li = courseRepo.getPendingSellers();
                return View("pendingsellers",li);
            }
            else
            {
                return View("Index","You must have to login first.");
            }
            
        }

        public IActionResult approveseller(int id)
        {
            if(HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword"))  //checking if cookie exists.
            {
                bool flag = sellerRepo.ApproveSeller(id);
                if(flag == true)
                {
                    ViewBag.appMessage = "Seller has been approved";
                }
                else
                {
                    ViewBag.appMessage = "There was an unexpected error in approving seller.";
                }
                List<Seller> li = courseRepo.getPendingSellers();
                return View("pendingsellers",li);
            }
            else
            {
                return View("Index","You must have to login first.");
            }
                
        }

        public IActionResult approvecourse(int id)
        {
            if(HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword"))  //checking if cookie exists.
            {
                bool flag = courseRepo.ApproveCourse(id);
                if(flag == true)
                {
                    ViewBag.appMessage = "Course has been approved";
                }
                else
                {
                    ViewBag.appMessage = "There was an unexpected error in approving course.";
                }
                List<Course> li = courseRepo.getPendingCourses();
                return View("pendingcourses",li);
            }
            else
            {
                return View("Index","You must have to login first.");
            }
            
        }

        public IActionResult unapproveseller(int id)
        {
            if(HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword"))  //checking if cookie exists.
            {
                bool flag = sellerRepo.UnApproveSeller(id);
                if(flag == true)
                {
                    ViewBag.appMessage = "Seller has been unapproved";
                }
                else
                {
                    ViewBag.appMessage = "There was an unexpected error in unapproving seller.";
                }
                List<Seller> li = courseRepo.getApprovedSellers();
                return View("approvedsellers",li);
            }
            else
            {
                return View("Index","You must have to login first.");
            }
                
        }
        public IActionResult unapprovecourse(int id)
        {
            if(HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword"))  //checking if cookie exists.
            {
                bool flag = courseRepo.UnApproveCourse(id);
                if(flag == true)
                {
                    ViewBag.appMessage = "Course has been unapproved";
                }
                else
                {
                    ViewBag.appMessage = "There was an unexpected error in unapproving course.";
                }
                List<Course> li = courseRepo.getApprovedCourses();
                return View("approvedcourses",li);
            }
            else
            {
                return View("Index","You must have to login first.");
            }
                
        }
        
        public IActionResult showusers()
        {
            if(HttpContext.Request.Cookies.ContainsKey("ausername") && HttpContext.Request.Cookies.ContainsKey("apassword"))  //checking if cookie exists.
            {
                List<Users> li = userRepo.GetAllUsers();
                List<UserViewModel> uvmli = new List<UserViewModel>();
                foreach(var item in li)
                {
                    UserViewModel uvm = imap.Map<UserViewModel>(item);
                    uvmli.Add(uvm);
                }
                // UserViewModel uvm = imap.Map<UserViewModel>(u);
                return View("showusers",uvmli);
            }
            else
            {
                return View("Index","You must have to login first.");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}