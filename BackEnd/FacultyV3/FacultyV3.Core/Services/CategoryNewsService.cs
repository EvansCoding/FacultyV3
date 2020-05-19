using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacultyV3.Core.Services
{
    public class CategoryNewsService : ICategoryNewsService
    {
        private IDataContext context;

        public CategoryNewsService(IDataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category_News> PageList(string name, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return context.Category_News.Where(x => x.Meta_Name.Contains(name)).OrderBy(x => x.Meta_Name).ToPagedList(page, pageSize);
            }
            return context.Category_News.Where(x => x.Parent == null).OrderBy(x => x.Meta_Name).ToPagedList(page, pageSize);
        }

        public Category_News GetCategoryByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Category_News.Find(ID);
            }
            catch (Exception)
            {
            }
            return null;
        }

        public List<Category_News> GetCategories()
        {
            try
            {
                return context.Category_News.Where(x => !x.Block).Select(x => x).OrderBy(x => x.Meta_Name).ToList();
            }
            catch (Exception)
            {
            }
            return null;
        }
       
    }
}
