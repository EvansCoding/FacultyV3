using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacultyV3.Core.Services
{
    public class VideoService : IVideoService
    {
        private IDataContext context;

        public VideoService(IDataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Video> PageList(string name, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return context.Videos.Where(x => x.Title.Contains(name)).OrderByDescending(x => new { x.Serial, x.Update_At }).ToPagedList(page, pageSize);
            }
            return context.Videos.OrderByDescending(x => new { x.Serial, x.Update_At }).ToPagedList(page, pageSize);
        }

        public Video GetVideoByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Videos.Find(ID);
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
