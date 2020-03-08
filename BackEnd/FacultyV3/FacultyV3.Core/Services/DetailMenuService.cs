using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Core.Models.Enums;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace FacultyV3.Core.Services
{
   public class DetailMenuService : IDetailMenuService
    {
        private  IDataContext context;
        public DetailMenuService(IDataContext context)
        {
            this.context = context;
        }

        #region  Area Admin
        public IEnumerable<Detail_Menu> PageList(string name, string category, string state, int page, int pageSize)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(state) && string.IsNullOrEmpty(category))
            {
                return context.Detail_Menus.OrderBy(x => x.Title).ToPagedList(page, pageSize);
            }

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(state) && !string.IsNullOrEmpty(category))
            {
                bool status = state == Status.Publish.ToString() ? true : false;
                try
                {
                    Guid CategoryID = new Guid(category);

                    return context.Detail_Menus.Where(x => x.Title.Contains(name) && x.Category_Menu.Id == CategoryID && x.Status == status).OrderBy(x => x.Update_At).ToPagedList(page, pageSize);
                }
                catch (Exception)
                {
                }
            }

            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(state) || !string.IsNullOrEmpty(category))
            {
                var posts = context.Detail_Menus.OrderBy(x => x.Title).ToList();
                Console.WriteLine(posts.First().Id);
                if (!string.IsNullOrEmpty(name))
                    posts = posts.Where(x => x.Title.Contains(name)).ToList();
                if (!string.IsNullOrEmpty(state))
                {
                    bool status = state == Status.Publish.ToString() ? true : false;
                    posts = posts.Where(x => x.Status == status).ToList();
                }
                if (!string.IsNullOrEmpty(category))
                {
                    try
                    {
                        Guid CategoryID = new Guid(category);
                        posts = posts.Where(x => x.Category_Menu.Id == CategoryID).ToList();
                    }
                    catch (Exception)
                    {
                    }
                }
                return posts.ToPagedList(page, pageSize);
            }

            return context.Detail_Menus.OrderBy(x => x.Title).ToPagedList(page, pageSize);
        }

        public Detail_Menu GetPostByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Detail_Menus.Find(ID);

            }
            catch (Exception)
            {
            }
            return null;
        }

        public Detail_Menu GetPostByName(string name)
        {
            return context.Detail_Menus.Where(x => x.Title == name)
                           .Include(x => x.Category_Menu)
                           .Include(x => x.Account)
                           .SingleOrDefault();
        }

        public List<Detail_Menu> GetPostsByName(string name)
        {
            return context.Detail_Menus.Where(x => x.Title == name)
                           .OrderBy(x => x.Update_At)
                           .Include(x => x.Category_Menu)
                           .Include(x => x.Account)
                           .ToList();
        }

        #endregion
    }
}
