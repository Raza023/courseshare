using System;
using Microsoft.AspNetCore.Mvc;

namespace webapp.ViewComponents
{
    [ViewComponent(Name = "CategorySummary")]
    public class CategorySummary: ViewComponent
    {
        public IViewComponentResult Invoke(string name,string description, string filename)
        {
            ViewBag.name = name;
            ViewBag.description = description;
            ViewBag.path = "~/images/categories/"+filename;
            // string data = description;
            return View("Default");
        }
    }
}