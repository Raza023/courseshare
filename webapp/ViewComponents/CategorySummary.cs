using System;
using Microsoft.AspNetCore.Mvc;

namespace webapp.ViewComponents
{
    [ViewComponent(Name = "CategorySummary")]
    public class CategorySummary: ViewComponent
    {
        public IViewComponentResult Invoke(string name,string description, string filename, string catpath)
        {
            ViewBag.name = name;
            ViewBag.description = description;
            ViewBag.path = "~/images/categories/"+filename;
            ViewBag.catpath = catpath;
            return View("Default");
        }
    }
}