using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyV3.Core.Services
{
    public class About_UsService : IAbout_UsService
    {
        private IDataContext context;

        public About_UsService(IDataContext context)
        {
            this.context = context;
        }

        public About_Us GetTop()
        {
            try
            {
                return context.About_Us.Select(x => x).Take(1).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public About_Us GetAbout_UsByID(string Id)
        {
            try
            {
                return context.About_Us.Where(x => x.Id == new Guid(Id)).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
