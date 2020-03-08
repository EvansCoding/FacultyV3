using FacultyV3.Core.Models.Entities;
using System.Collections.Generic;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface ICategoryMenuService
    {
        Category_Menu GetCategoryByID(string id);
        Category_Menu GetCategoryByName(string name);
        IEnumerable<Category_Menu> PageList(string name, int page, int pageSize);
        List<Category_Menu> GetCategories();
        List<Category_Menu> GetCategoriesByParent(string name);
    }
}
