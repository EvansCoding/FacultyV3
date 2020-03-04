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
    public class AdsService : IAdsService
    {
        public IDataContext context;
        public AdsService(IDataContext context)
        {
            this.context = context;
        }
        public Ads GetTop()
        {
            try
            {
                return context.Adss.Select(x => x).Take(1).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public Ads GetAdsByID(string Id)
        {
            try
            {
                return context.Adss.Where(x => x.Id == new Guid(Id)).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
