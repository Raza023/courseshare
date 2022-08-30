using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using webapp.Models;
using webapp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace webapp.Controllers
{
    public class SignupController : Controller
    {
        private readonly ILogger<SignupController> _logger;
        private readonly IUsers userRepo;
        private readonly ICategory categoryRepo;

        public SignupController(ILogger<SignupController> logger, IUsers iu, ICategory ic)
        {
            _logger = logger;
            userRepo = iu;
            categoryRepo = ic;
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                Users u = new Users { Username = Username, Password = Password };
                bool flag = userRepo.getData(u);
                if(flag)
                {
                    if(HttpContext.Request.Cookies.ContainsKey("username") && HttpContext.Request.Cookies.ContainsKey("password"))  //checking if cookie exists.
                    {
                        //updating cookies
                        HttpContext.Response.Cookies.Delete("username");
                        HttpContext.Response.Cookies.Delete("password");
                        CookieOptions option = new CookieOptions();          //for it add using Microsoft.AspNetCore.Http;
                        option.Expires = System.DateTime.Now.AddDays(10);     //Now cookie will expire after a day. if you want cookies to be saved after closing browser as well.
                        HttpContext.Response.Cookies.Append("username", u.Username,option);
                        HttpContext.Response.Cookies.Append("password", u.Password,option);
                    }
                    else
                    {
                        //defining cookies.
                        CookieOptions option = new CookieOptions();
                        option.Expires = System.DateTime.Now.AddDays(10);
                        HttpContext.Response.Cookies.Append("username", u.Username ,option);
                        HttpContext.Response.Cookies.Append("password", u.Password ,option);
                    }

                    ViewBag.x = "Successfully logged in.";
                    List<Category> li = new List<Category>();
                    //Category c = new Category();
                    li = categoryRepo.getCategoriesList();
                    return View("~/Views/Home/Index.cshtml",li);
                }
                else
                {
                    ViewBag.x = "Username or password is incorrect.";
                    return View("login");
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult signup(Users u)
        {
            //Users u = new Users {Name=fname,Email=femail,Username=fusername,Password=fpassword };
            if (ModelState.IsValid)
            {
                if(!userRepo.checkUsername(u))
                {
                    int id = userRepo.insertData(u);
                    if(id>0)
                    {
                        if(HttpContext.Request.Cookies.ContainsKey("username") && HttpContext.Request.Cookies.ContainsKey("password"))  //checking if cookie exists.
                        {
                            //updating cookies
                            HttpContext.Response.Cookies.Delete("username");
                            HttpContext.Response.Cookies.Delete("password");
                            CookieOptions option = new CookieOptions();          //for it add using Microsoft.AspNetCore.Http;
                            option.Expires = System.DateTime.Now.AddDays(10);     //Now cookie will expire after a day. if you want cookies to be saved after closing browser as well.
                            HttpContext.Response.Cookies.Append("username", u.Username, option);
                            HttpContext.Response.Cookies.Append("password", u.Password, option);
                        }
                        else
                        {
                            //defining cookies.
                            CookieOptions option = new CookieOptions();
                            option.Expires = System.DateTime.Now.AddDays(10);
                            HttpContext.Response.Cookies.Append("username", u.Username, option);
                            HttpContext.Response.Cookies.Append("password", u.Password, option);
                        }
                        
                        ViewBag.x = true;
                        ViewBag.data = "Successfully Registered.";
                        return View("signup");
                    }
                    else
                    {
                        ViewBag.x = false;
                        ViewBag.data = "There was an error in signing up.";
                        return View("signup");
                    }
                }
                else
                {
                    ViewBag.x = false;
                    ViewBag.data = "Username or Email already exists.";
                    return View("signup");
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult logout()
        {
            HttpContext.Response.Cookies.Delete("username");
            HttpContext.Response.Cookies.Delete("password");

            ViewBag.lgout = true;
            ViewBag.data = "Logged out";
            List<Category> li = new List<Category>();
            //Category c = new Category();
            li = categoryRepo.getCategoriesList();
            return View("~/Views/Home/Index.cshtml",li);
        }
    }
}