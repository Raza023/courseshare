using System;
using Microsoft.AspNetCore.Mvc;

namespace webapp.ViewComponents
{
    [ViewComponent(Name = "ProductsSummary")]
    public class ProductsSummary: ViewComponent
    {
        public IViewComponentResult Invoke(string p1,int p2)
        {
            string data=$"{p1}'s price is {p2}";
            ViewBag.color = "Yellow";
            return View("Default",data);
        }
    }
}
