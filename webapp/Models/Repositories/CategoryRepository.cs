using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models.Interfaces;

namespace webapp.Models.Repositories
{
    public class CategoryRepository: ICategory
    {
        public List<Category> getCategoriesList()
        {
            CourseContext db = new CourseContext();
            List<Category> li = db.Categories.Where(p => p.ID > 0).ToList();
            return li;
        }

        public List<Category> getCategoriesData(string data)
        {
            CourseContext db = new CourseContext();
            List<Category> li = db.Categories.Where(p => p.categoryName.ToLower().Contains(data.ToLower())).ToList();
            return li;
        }
    }
}