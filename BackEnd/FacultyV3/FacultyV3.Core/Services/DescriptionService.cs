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
    public class DescriptionService : IDescriptionService
    {
        private IDataContext context;
        public DescriptionService(IDataContext context)
        {
            this.context = context;
        }

        public List<Service> GetServices()
        {
            try
            {
                return context.Services.OrderBy(x => x.Meta_Name)
                    .Select(x => x).ToList();
            }
            catch (Exception)
            {

            }
            return null;
        }

        public Service GetServiceByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Services.Find(ID);
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
