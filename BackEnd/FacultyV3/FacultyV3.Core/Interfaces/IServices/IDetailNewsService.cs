using FacultyV3.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface IDetailNewsService
    {
        IEnumerable<Detail_News> PageList(string name, string category, string state, int page, int pageSize);

        Detail_News GetPostByID(string id);

        Detail_News GetPostByName(string name);

        List<Detail_News> GetPostsByName(string name);

        List<Detail_News> GetPostsByCategory(string category);

        List<Detail_News> GetPostTop(int amount);
    }
}
