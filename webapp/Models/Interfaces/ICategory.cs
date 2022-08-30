using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Models.Interfaces
{
    public interface ICategory
    {
        public List<Category> getCategoriesList();
        public List<Category> getCategoriesData(string data);
    }
}