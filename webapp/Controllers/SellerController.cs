
using System.Net;
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
using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Schema;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Web;


namespace webapp.Controllers
{
    public class SellerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsers userRepo;
        private readonly ICategory categoryRepo;
        private readonly ISeller sellerRepo;
        private readonly ICourse courseRepo;
        private IWebHostEnvironment Environment;

        public SellerController(ILogger<HomeController> logger, IUsers iu, ICategory ic, ISeller isr, ICourse cr, IWebHostEnvironment _environment)
        {
            _logger = logger;
            userRepo = iu;
            categoryRepo = ic;
            sellerRepo = isr;
            courseRepo = cr;
            Environment = _environment;
        }

        public IActionResult Index()
        {
            if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
            {
                List<Course> li = courseRepo.getSellerCourses(sellerRepo.getSellerId(HttpContext.Request.Cookies["susername"]));
                return View("Index",li);
            }
            else
            {
                ViewBag.lgout = true;
                ViewBag.data = "You must have to login first as a seller.";
                List<Category> li = new List<Category>();
                //Category c = new Category();
                li = categoryRepo.getCategoriesList();
                return View("~/Views/Home/Index.cshtml",li);
            }
        }

        public IActionResult deletecourse(int id)
        {
            if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
            {
                string wwwPath = this.Environment.WebRootPath;
                // string contentPath = this.Environment.ContentRootPath;
        
                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                path = Path.Combine(path, "Thumbnails");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = courseRepo.getCourseThumbnailName(id);
                if (System.IO.File.Exists(Path.Combine(path, fileName)))
                {
                    // If file found, delete it.
                    System.IO.File.Delete(Path.Combine(path, fileName));
                    // ViewBag.sMessage = "Your Course has been deleted.";
                }
                else
                {
                    ViewBag.Message = "Course not found";
                }

                string vpath = Path.Combine(this.Environment.WebRootPath, "Uploads");
                vpath = Path.Combine(vpath, "Videos");
                if (!Directory.Exists(vpath))
                {
                    Directory.CreateDirectory(vpath);
                }
                List<Video> vlist = courseRepo.getCourseVideos(id);
                foreach (var v in vlist)
                {
                    if (System.IO.File.Exists(Path.Combine(vpath, v.videoName)))
                    {
                        // If file found, delete it.
                        System.IO.File.Delete(Path.Combine(vpath, v.videoName));
                        // ViewBag.sMessage = "Your Course has been deleted.";
                    }
                    else
                    {
                        ViewBag.Message = "Video not found";
                    }
                }

                bool flag = courseRepo.deleteCourse(id);
                flag = courseRepo.deleteCourseVideos(id);

                if(flag == true)
                {
                    ViewBag.showMyMsg = "Course has been deleted successfully!";
                    List<Course> li = courseRepo.getSellerCourses(sellerRepo.getSellerId(HttpContext.Request.Cookies["susername"]));
                    return View("Index",li);
                }
                else
                {
                    ViewBag.showMyMsg = "There was an error in deleting this course.";
                    List<Course> li = courseRepo.getSellerCourses(sellerRepo.getSellerId(HttpContext.Request.Cookies["susername"]));
                    return View("Index",li);
                }
            }
            else
            {
                ViewBag.lgout = true;
                ViewBag.data = "You must have to login first as a seller.";
                List<Category> li = new List<Category>();
                //Category c = new Category();
                li = categoryRepo.getCategoriesList();
                return View("~/Views/Home/Index.cshtml",li);
            }
        }

        [HttpGet]
        public IActionResult updatecourse(int id)
        {
            if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
            {
                Course c = courseRepo.getCourse(id);
                return View("updatecourse",c);
            }
            else
            {
                ViewBag.lgout = true;
                ViewBag.data = "You must have to login first as a seller.";
                List<Category> li = new List<Category>();
                //Category c = new Category();
                li = categoryRepo.getCategoriesList();
                return View("~/Views/Home/Index.cshtml",li);
            }
        }

        [HttpPost]
        public IActionResult updatecourse(string courseId, string coursename, string coursedescription, string categorytype, List<IFormFile> postedFiles)
        {
            if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
            {
                int courseid = Int32.Parse(courseId);
                try
                {
                    string wwwPath = this.Environment.WebRootPath;
                    // string contentPath = this.Environment.ContentRootPath;
            
                    string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                    path = Path.Combine(path, "Thumbnails");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    foreach (IFormFile postedFile in postedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        string extension = Path.GetExtension(postedFile.FileName);
                        
                        if(extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png" || extension.ToLower() == ".tiff" || extension.ToLower() == ".gif" || extension.ToLower() == ".webp")
                        {
                            fileName = courseRepo.getCourseThumbnailName(courseid);
                            if (System.IO.File.Exists(Path.Combine(path, fileName)))
                            {
                                // If file found, delete it.
                                System.IO.File.Delete(Path.Combine(path, fileName));
                                // ViewBag.sMessage =  "Your Course has been deleted.";
                            }
                            else
                            {
                                ViewBag.Message = "Course not found";
                            }
                            
                            Course c = new Course{courseName = coursename, courseDescription = coursedescription, category = categorytype, courseThumbnail=fileName, SellerId=sellerRepo.getSellerId(HttpContext.Request.Cookies["susername"])};
                            bool flag = courseRepo.updateCourse(courseid, c);

                            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                            {
                                postedFile.CopyTo(stream);
                                
                                if(flag)
                                {
                                    ViewBag.sMessage += string.Format("<b>Your course has been updated successfully!</b> <br />");
                                }
                                else
                                {
                                    ViewBag.Message += string.Format("Course thumbnail has been changed.<br />");
                                }
                            }
                        }
                        else
                        {
                            ViewBag.Message += string.Format("Error: <b>{0}</b> not uploaded because this extension is not supported.<br />", fileName);
                        }
                    }
                }  
                catch (Exception ex)  
                {
                    ViewBag.Message = "ERROR: File size " + ex.Message.ToString();
                }
                List<Course> li = courseRepo.getSellerCourses(sellerRepo.getSellerId(HttpContext.Request.Cookies["susername"]));
                return View("Index",li);
            }
            else
            {
                ViewBag.lgout = true;
                ViewBag.data = "You must have to login first as a seller.";
                List<Category> li = new List<Category>();
                //Category c = new Category();
                li = categoryRepo.getCategoriesList();
                return View("~/Views/Home/Index.cshtml",li);
            }
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
                Seller s = new Seller { Username = Username, Password = Password };
                bool flag = sellerRepo.getData(s);
                if(flag)
                {
                    if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
                    {
                        //updating cookies
                        HttpContext.Response.Cookies.Delete("susername");
                        HttpContext.Response.Cookies.Delete("spassword");
                        CookieOptions option = new CookieOptions();          //for it add using Microsoft.AspNetCore.Http;
                        option.Expires = System.DateTime.Now.AddDays(10);     //Now cookie will expire after a day. if you want cookies to be saved after closing browser as well.
                        HttpContext.Response.Cookies.Append("susername", s.Username,option);
                        HttpContext.Response.Cookies.Append("spassword", s.Password,option);
                    }
                    else
                    {
                        //defining cookies.
                        CookieOptions option = new CookieOptions();
                        option.Expires = System.DateTime.Now.AddDays(10);
                        HttpContext.Response.Cookies.Append("susername", s.Username ,option);
                        HttpContext.Response.Cookies.Append("spassword", s.Password ,option);
                    }

                    ViewBag.x = "Successfully logged in.";
                    // List<Course> li = courseRepo.getSellerCourses(sellerRepo.getSellerId(HttpContext.Request.Cookies["susername"]));
                    return RedirectToAction("Index","Seller");
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
        public IActionResult signup(Seller s)
        {
            //Seller s = new Seller {Name=fname,Email=femail,Username=fusername,Password=fpassword };
            if (ModelState.IsValid)
            {
                if(!sellerRepo.checkUsername(s))
                {
                    int id = sellerRepo.insertData(s);
                    if(id>0)
                    {
                        if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
                        {
                            //updating cookies
                            HttpContext.Response.Cookies.Delete("susername");
                            HttpContext.Response.Cookies.Delete("spassword");
                            CookieOptions option = new CookieOptions();          //for it add using Microsoft.AspNetCore.Http;
                            option.Expires = System.DateTime.Now.AddDays(10);     //Now cookie will expire after a day. if you want cookies to be saved after closing browser as well.
                            HttpContext.Response.Cookies.Append("susername", s.Username, option);
                            HttpContext.Response.Cookies.Append("spassword", s.Password, option);
                        }
                        else
                        {
                            //defining cookies.
                            CookieOptions option = new CookieOptions();
                            option.Expires = System.DateTime.Now.AddDays(10);
                            HttpContext.Response.Cookies.Append("susername", s.Username, option);
                            HttpContext.Response.Cookies.Append("spassword", s.Password, option);
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

        [HttpGet]
        public IActionResult addcourse()
        {
            if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
            {
                return View();
            }
            else
            {
                ViewBag.lgout = true;
                ViewBag.data = "You must have to login first as a seller.";
                List<Category> li = new List<Category>();
                //Category c = new Category();
                li = categoryRepo.getCategoriesList();
                return View("~/Views/Home/Index.cshtml",li);
            }
        }

        [HttpPost]
        [RequestSizeLimit(209715200)]  //200 MB limit
        public IActionResult addcourse(string coursename, string coursedescription, string categorytype, List<IFormFile> postedFiles)
        {
            if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
            {
                try
                {
                    string wwwPath = this.Environment.WebRootPath;
                    // string contentPath = this.Environment.ContentRootPath;
            
                    string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                    path = Path.Combine(path, "Thumbnails");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    List<string> uploadedFiles = new List<string>();
                    foreach (IFormFile postedFile in postedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        string extension = Path.GetExtension(postedFile.FileName);
                        
                        if(extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png" || extension.ToLower() == ".tiff" || extension.ToLower() == ".gif" || extension.ToLower() == ".webp")
                        {
                            fileName = "auxiname"+extension;
                            Course c = new Course{courseName = coursename, courseDescription = coursedescription, category = categorytype, courseThumbnail=fileName, SellerId=sellerRepo.getSellerId(HttpContext.Request.Cookies["susername"])};
                            int cid = sellerRepo.addCourse(c);
                            fileName = ""+cid+extension;
                            Course c2 = new Course{courseName = coursename, courseDescription = coursedescription, category = categorytype, courseThumbnail=fileName, SellerId=sellerRepo.getSellerId(HttpContext.Request.Cookies["susername"])};
                            cid = sellerRepo.updateThumbnail(c2);

                            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                            {
                                postedFile.CopyTo(stream);
                                uploadedFiles.Add(fileName);
                                
                                if(cid>0)
                                {
                                    ViewBag.sMessage += string.Format("<b>Your course has been created successfully!</b> <br />");
                                }
                                else
                                {
                                    ViewBag.Message += string.Format("Error: <b>{0}</b> not uploaded.<br />", fileName);
                                }
                            }
                        }
                        else
                        {
                            ViewBag.Message += string.Format("Error: <b>{0}</b> not uploaded because this extension is not supported.<br />", fileName);
                        }
                    }
                }  
                catch (Exception ex)  
                {
                    ViewBag.Message = "ERROR: File size " + ex.Message.ToString();
                }
                return View();
            }
            else
            {
                ViewBag.lgout = true;
                ViewBag.data = "You must have to login first as a seller.";
                List<Category> li = new List<Category>();
                //Category c = new Category();
                li = categoryRepo.getCategoriesList();
                return View("~/Views/Home/Index.cshtml",li);
            }
        }

        [HttpGet]
        public IActionResult addvideo(int id)
        {
            if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
            {
                Course c = new Course();
                c = courseRepo.getCourse(id);
                return View("addvideo",c);
            }
            else
            {
                ViewBag.lgout = true;
                ViewBag.data = "You must have to login first as a seller.";
                List<Category> li = new List<Category>();
                //Category c = new Category();
                li = categoryRepo.getCategoriesList();
                return View("~/Views/Home/Index.cshtml",li);
            }
        }

        [HttpPost]
        [RequestSizeLimit(209715200)]  //200 MB limit
        public IActionResult addvideo(string courseid, string videotitle, List<IFormFile> postedFiles)
        {
            if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
            {
                int courId = Int32.Parse(courseid);
                try
                {
                    string wwwPath = this.Environment.WebRootPath;
                    // string contentPath = this.Environment.ContentRootPath;
            
                    string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                    path = Path.Combine(path, "Videos");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    List<string> uploadedFiles = new List<string>();
                    foreach (IFormFile postedFile in postedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        string extension = Path.GetExtension(postedFile.FileName);
                        
                        if(extension.ToLower() == ".mp4" || extension.ToLower() == ".mov" || extension.ToLower() == ".flv" || extension.ToLower() == ".ts" || extension.ToLower() == ".3gp" || extension.ToLower() == ".m3u8" || extension.ToLower() == ".avi" || extension.ToLower() == ".wmv" || extension.ToLower() == ".webm")
                        {
                            fileName = "auxiname"+extension;
                            Video v = new Video{videoName = fileName, videoTitle = videotitle, CourseId = courId};
                            int vid = sellerRepo.addVideo(v);
                            fileName = ""+vid+extension;
                            Video v2 = new Video{videoName = fileName, videoTitle = videotitle, CourseId = courId};
                            vid = sellerRepo.updateVideoName(v2);

                            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                            {
                                postedFile.CopyTo(stream);
                                uploadedFiles.Add(fileName);
                                
                                if(vid>0)
                                {
                                    ViewBag.sMessage += string.Format("<b>Your video has been added successfully!</b> <br />");
                                }
                                else
                                {
                                    ViewBag.Message += string.Format("Error: <b>{0}</b> not uploaded.<br />", fileName);
                                }
                            }
                        }
                        else
                        {
                            ViewBag.Message += string.Format("Error: <b>{0}</b> not uploaded because this extension is not supported.<br />", fileName);
                        }
                    }
                }  
                catch (Exception ex)  
                {
                    ViewBag.Message = "ERROR: File size " + ex.Message.ToString();
                }
                Course c = new Course();
                c = courseRepo.getCourse(courId);
                return View("addvideo",c);
            }
            else
            {
                ViewBag.lgout = true;
                ViewBag.data = "You must have to login first as a seller.";
                List<Category> li = new List<Category>();
                //Category c = new Category();
                li = categoryRepo.getCategoriesList();
                return View("~/Views/Home/Index.cshtml",li);
            }
        }

        public IActionResult logout()
        {
            HttpContext.Response.Cookies.Delete("susername");
            HttpContext.Response.Cookies.Delete("spassword");

            ViewBag.lgout = true;
            ViewBag.data = "Logged out";
            List<Category> li = new List<Category>();
            //Category c = new Category();
            li = categoryRepo.getCategoriesList();
            return View("~/Views/Home/Index.cshtml",li);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}