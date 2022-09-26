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
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsers userRepo;
        private readonly ICategory categoryRepo;

        public AdminController(ILogger<HomeController> logger, IUsers iu, ICategory ic)
        {
            _logger = logger;
            userRepo = iu;
            categoryRepo = ic;
        }
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}