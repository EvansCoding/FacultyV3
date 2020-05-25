using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacultyV3.Core.Services
{
    public class BannerService : IBannerService
    {
        private IDataContext context;

        public BannerService(IDataContext context)
        {
            this.context = context;
        }

        public List<Banner> GetBannersOrderBySerial(int amount)
        {
            try
            {
                var model = context.Banners.OrderByDescending(x => x.Update_At).ToList();

                var data = model.OrderByDescending(x => x.Serial).Select(x => x).Take(amount).ToList();
                return data;
            }
            catch (Exception)
            {

            }
            return null;
        }

        public List<Banner> GetBanners()
        {
            try
            {
                return context.Banners
                    .Select(x => x).ToList();
            }
            catch (Exception)
            {

            }
            return null;
        }

        public IEnumerable<Banner> PageList(string name, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return context.Banners.Where(x => x.Title.Contains(name)).OrderByDescending(x => new { x.Serial, x.Update_At }).ToPagedList(page, pageSize);
            }
            return context.Banners.OrderByDescending(x => new { x.Serial, x.Update_At}).ToPagedList(page, pageSize);
        }

        public List<Banner> GetBannersByName(string name)
        {
            try
            {
                return context.Banners
                    .Where(x => x.Title == name)
                    .Select(x => x).ToList();
            }
            catch (Exception)
            {

            }
            return null;
        }

        public Banner GetBannerByName(string name)
        {
            try
            {
                return context.Banners
                    .Where(x => x.Title == name).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public Banner GetBannerByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Banners.Find(ID);
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
