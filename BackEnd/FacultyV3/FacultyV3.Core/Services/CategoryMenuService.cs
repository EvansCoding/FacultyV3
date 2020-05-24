using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace FacultyV3.Core.Services
{
    public class CategoryMenuService : ICategoryMenuService
    {
        private IDataContext context;

        public CategoryMenuService(IDataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category_Menu> PageList(string name, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return context.Category_Menus.Where(x => x.Meta_Name.Contains(name)).OrderBy(x => x.Meta_Name).ToPagedList(page, pageSize);
            }
            return context.Category_Menus.Where(x => x.Parent == null).OrderBy(x => x.Meta_Name).ToPagedList(page, pageSize);
        }

        public Category_Menu GetCategoryByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Category_Menus.Include(x => x.Parent).Where(x => x.Id == ID).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public List<Category_Menu> GetCategoriesByParent(string name)
        {
            try
            {
                return context.Category_Menus.Include(x => x.Parent)
                                .Where(x => x.Parent.Meta_Name == name)
                                .OrderByDescending(x => x.Serial)
                                .Select(x => x).ToList();
            }
            catch (Exception)
            {

            }
            return null;
        }

        public Category_Menu GetCategoryByName(string name)
        {
            try
            {
                return context.Category_Menus.Where(x => x.Meta_Name.Contains(name)).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }
        public List<Category_Menu> GetCategories()
        {
            try
            {
                return context.Category_Menus.Select(x => x).OrderBy(x => x.Meta_Name).ToList();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public List<Category_Menu> GetBlockCategories()
        {
            try
            {
                return context.Category_Menus.Select(x => x).OrderBy(x => x.Meta_Name).ToList();
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
