using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacultyV3.Core.Services
{
    public class StickyService : IStickyService
    {
        private IDataContext context;
        public StickyService(IDataContext context)
        {
            this.context = context;
        }

        public Stickey GetStickyByID(string id)
        {
            try
            {
                return context.Stickeys.Where(x => x.Id == new Guid(id)).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public List<Stickey> GetStickys()
        {
            try
            {
                return context.Stickeys.OrderBy(x => x.Meta_Name).ToList();
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
