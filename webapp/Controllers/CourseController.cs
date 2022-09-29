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
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICategory categoryRepo;
        private readonly ICourse courseRepo;
        private readonly ISeller sellerRepo;
        private IWebHostEnvironment Environment;

        public CourseController(ILogger<CourseController> logger, IUsers iu, ISeller isr, ICategory ic, ICourse icr, IWebHostEnvironment _environment)
        {
            _logger = logger;
            categoryRepo = ic;
            sellerRepo = isr;
            courseRepo = icr;
            Environment = _environment;
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
            if(HttpContext.Request.Cookies.ContainsKey("username") && HttpContext.Request.Cookies.ContainsKey("password"))  //checking if cookie exists.
            {
                return View();
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

        public IActionResult Development()
        {
            if(HttpContext.Request.Cookies.ContainsKey("username") && HttpContext.Request.Cookies.ContainsKey("password"))  //checking if cookie exists.
            {
                List<Course> li = courseRepo.getDevelopmentCourses();
                return View("Development",li);
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

        public IActionResult PhotographyAndVideo()
        {
            if(HttpContext.Request.Cookies.ContainsKey("username") && HttpContext.Request.Cookies.ContainsKey("password"))  //checking if cookie exists.
            {
                List<Course> li = courseRepo.getPhotographyCourses();
                return View("PhotographyAndVideo",li);
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

        public IActionResult TeachingAndAcademic()
        {
            if(HttpContext.Request.Cookies.ContainsKey("username") && HttpContext.Request.Cookies.ContainsKey("password"))  //checking if cookie exists.
            {
                List<Course> li = courseRepo.getTeachingCourses();
                return View("TeachingAndAcademic",li);
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

        public IActionResult Design()
        {
            if(HttpContext.Request.Cookies.ContainsKey("username") && HttpContext.Request.Cookies.ContainsKey("password"))  //checking if cookie exists.
            {
                List<Course> li = courseRepo.getDesignCourses();
                return View("Design",li);
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

        public IActionResult HealthAndFitness()
        {
            if(HttpContext.Request.Cookies.ContainsKey("username") && HttpContext.Request.Cookies.ContainsKey("password"))  //checking if cookie exists.
            {
                List<Course> li = courseRepo.getHealthCourses();
                return View("HealthAndFitness",li);
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

        public IActionResult Business()
        {
            if(HttpContext.Request.Cookies.ContainsKey("username") && HttpContext.Request.Cookies.ContainsKey("password"))  //checking if cookie exists.
            {
                List<Course> li = courseRepo.getBusinessCourses();
                return View("Business",li);
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

        public IActionResult details(int id)     //must use id here.
        {
            if(HttpContext.Request.Cookies.ContainsKey("username") && HttpContext.Request.Cookies.ContainsKey("password"))  //checking if cookie exists.
            {
                List<Video> li = courseRepo.getCourseVideos(id);
                return View("details",li);
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

        public IActionResult sellersidedetails(int id)     //must use id here.
        {
            if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
            {
                List<Video> li = courseRepo.getCourseVideos(id);
                return View("sellersidedetails",li);
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

        public IActionResult videodetails(int id)     //must use id here.
        {
            if(HttpContext.Request.Cookies.ContainsKey("username") && HttpContext.Request.Cookies.ContainsKey("password"))  //checking if cookie exists.
            {
                Video v = courseRepo.getCourseVideo(id);
                ViewBag.vpath = "~/Uploads/Videos/"+v.videoName;
                return View("videodetails",v);
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

        public IActionResult deletevideo(int id)
        {
            if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
            {
                string wwwPath = this.Environment.WebRootPath;
        
                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                path = Path.Combine(path, "Videos");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = courseRepo.getCourseVideoName(id);
                if (System.IO.File.Exists(Path.Combine(path, fileName)))
                {
                    // If file found, delete it.
                    System.IO.File.Delete(Path.Combine(path, fileName));
                    // ViewBag.sMessage = "Your Course has been deleted.";
                }
                else
                {
                    ViewBag.Message = "Video not found";
                }
                bool flag = courseRepo.deleteVideo(id);
                if(flag == true)
                {
                    ViewBag.showMyMsg = "Video has been deleted successfully!";
                    List<Course> li = courseRepo.getSellerCourses(sellerRepo.getSellerId(HttpContext.Request.Cookies["susername"]));
                    return View("~/Views/Seller/Index.cshtml",li);
                }
                else
                {
                    ViewBag.showMyMsg = "There was an error in deleting this Video.";
                    List<Course> li = courseRepo.getSellerCourses(sellerRepo.getSellerId(HttpContext.Request.Cookies["susername"]));
                    return View("~/Views/Seller/Index.cshtml",li);
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
        public IActionResult updatevideo(int id)
        {
            if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
            {
                Video v = courseRepo.getCourseVideo(id);
                return View("updatevideo",v);
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
        [RequestSizeLimit(209715200)]
        public IActionResult updatevideo(string vid, string courseId, string videotitle, List<IFormFile> postedFiles)
        {
            if(HttpContext.Request.Cookies.ContainsKey("susername") && HttpContext.Request.Cookies.ContainsKey("spassword"))  //checking if cookie exists.
            {
                int videoid = Int32.Parse(vid);
                int courseid = Int32.Parse(courseId);
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

                    foreach (IFormFile postedFile in postedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        string extension = Path.GetExtension(postedFile.FileName);
                        
                        if(extension.ToLower() == ".mp4" || extension.ToLower() == ".mov" || extension.ToLower() == ".flv" || extension.ToLower() == ".ts" || extension.ToLower() == ".3gp" || extension.ToLower() == ".m3u8" || extension.ToLower() == ".avi" || extension.ToLower() == ".wmv" || extension.ToLower() == ".webm")
                        {
                            fileName = courseRepo.getCourseVideoName(videoid);
                            if (System.IO.File.Exists(Path.Combine(path, fileName)))
                            {
                                // If file found, delete it.
                                System.IO.File.Delete(Path.Combine(path, fileName));
                                // ViewBag.sMessage =  "Your Video has been deleted.";
                            }
                            else
                            {
                                ViewBag.Message = "Video not found";
                            }
                            
                            Video v = new Video{videoName = fileName, videoTitle = videotitle, CourseId = courseid};
                            bool flag = courseRepo.updateVideo(videoid, v);

                            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                            {
                                postedFile.CopyTo(stream);
                                
                                if(flag)
                                {
                                    ViewBag.sMessage += string.Format("<b>Your video has been updated successfully!</b> <br />");
                                }
                                else
                                {
                                    ViewBag.Message += string.Format("Course video has been changed.<br />");
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
                return View("~/Views/Seller/Index.cshtml",li);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}