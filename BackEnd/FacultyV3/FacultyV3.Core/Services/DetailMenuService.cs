using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Core.Models.Enums;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace FacultyV3.Core.Services
{
    public class DetailMenuService : IDetailMenuService
    {
        private IDataContext context;
        public DetailMenuService(IDataContext context)
        {
            this.context = context;
        }

        #region  Area Admin
        public IEnumerable<Detail_Menu> PageList(string account, string name, string category, string state, int page, int pageSize)
        {
            try
            {
                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(state) && string.IsNullOrEmpty(category))
                {
                    return context.Detail_Menus.Include(x => x.Category_Menu).Include(x => x.Account).Where(x => x.Account.Id == new Guid(account)).OrderByDescending(x => x.Update_At).ToPagedList(page, pageSize);
                }

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(state) && !string.IsNullOrEmpty(category))
                {
                    bool status = state == Status.Publish.ToString() ? true : false;
                    try
                    {
                        Guid CategoryID = new Guid(category);

                        return context.Detail_Menus.Include(x => x.Category_Menu).Include(x => x.Account).Where(x => x.Title.Contains(name) && x.Category_Menu.Id == CategoryID && x.Status == status && x.Account.Id == new Guid(account)).OrderByDescending(x => x.Update_At).ToPagedList(page, pageSize);
                    }
                    catch (Exception)
                    {
                    }
                }

                if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(state) || !string.IsNullOrEmpty(category))
                {
                    var posts = context.Detail_Menus.Include(x => x.Category_Menu).Include(x => x.Account).Where(x => x.Account.Id == new Guid(account)).OrderBy(x => x.Title).ToList();

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

                return context.Detail_Menus.Include(x => x.Category_Menu).Include(x => x.Account).Where(x => x.Account.Id == new Guid(account)).OrderByDescending(x => x.Update_At).ToPagedList(page, pageSize);
            }
            catch (Exception)
            {
            }
            return null;
        }


        public IEnumerable<Detail_Menu> PageListFE(string category, int page, int pageSize)
        {
            return context.Detail_Menus
                .Include(x => x.Account)
                .Include(x => x.Category_Menu)
                .Where(x => x.Category_Menu.Meta_Name.Equals(category) && x.Status).OrderByDescending(x => new { x.Update_At, x.Serial}).ToPagedList(page, pageSize);
        }


        public Detail_Menu GetPostByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Detail_Menus.Include(x => x.Account).Include(x => x.Category_Menu).Where(x => x.Id == ID).SingleOrDefault();

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
                           .OrderByDescending(x => x.Update_At)
                           .Include(x => x.Category_Menu)
                           .Include(x => x.Account)
                           .ToList();
        }

        public List<Detail_Menu> GetPostsByCategory(string category)
        {
            try
            {
                return context.Detail_Menus
                    .Include(x => x.Account)
                    .Include(x => x.Category_Menu)
                    .Where(x => x.Category_Menu.Meta_Name.Equals(category)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
