using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace webapp.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }
        public string categoryPicture { get; set; }
        public string categoryPath { get; set; }

        public List<Category> getCategoriesList()
        {
            CourseContext db = new CourseContext();
            List<Category> li = db.Categories.Where(p => p.ID > 0).ToList();
            return li;
        }
    }
}