using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;

namespace webapp.Controllers
{
    public class SignupController : Controller
    {
        
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
                bool flag = u.getData(u);
                if(flag)
                {
                    ViewBag.x = "Successfully logged in.";
                    return View("Index");
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
                if(!u.checkUsername(u))
                {
                    bool flag = u.insertData(u);
                    if(flag)
                    {
                        ViewBag.x = flag;
                        ViewBag.data = "Successfully Registered";
                        return View("signup");
                    }
                    else
                    {
                        ViewBag.x = flag;
                        ViewBag.data = "There was an error in signing up.";
                        return View("signup");
                    }
                }
                else
                {
                    ViewBag.x = false;
                    ViewBag.data = "Username alreay exists.";
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
            ViewBag.lgout = true;
            ViewBag.data = "Logged out";
            return View("~/Views/Home/Index.cshtml");
        }
    }
}