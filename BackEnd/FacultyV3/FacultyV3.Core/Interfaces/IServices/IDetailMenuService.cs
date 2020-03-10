using FacultyV3.Core.Models.Entities;
using System.Collections.Generic;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface IDetailMenuService
    {
        IEnumerable<Detail_Menu> PageList(string name, string category, string state, int page, int pageSize);

        Detail_Menu GetPostByID(string id);

        Detail_Menu GetPostByName(string name);

        List<Detail_Menu> GetPostsByName(string name);

        List<Detail_Menu> GetPostsByCategory(string category);
    }
}
