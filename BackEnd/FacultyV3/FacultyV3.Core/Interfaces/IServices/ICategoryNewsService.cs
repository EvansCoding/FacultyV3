using FacultyV3.Core.Models.Entities;
using System.Collections.Generic;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface ICategoryNewsService
    {
        Category_News GetCategoryByID(string id);
        IEnumerable<Category_News> PageList(string name, int page, int pageSize);
        List<Category_News> GetCategories();
    }
}
