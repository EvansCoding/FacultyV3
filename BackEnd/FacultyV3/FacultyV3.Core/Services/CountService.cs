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
    public class CountService : ICountService
    {
        private IDataContext context;
        public CountService(IDataContext context)
        {
            this.context = context;
        }
        public List<Count> GetCounts()
        {
            try
            {
                return context.Counts
                    .Select(x => x).ToList();
            }
            catch (Exception)
            {

            }
            return null;
        }

        public Count GetCountByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Counts.Find(ID);
            }
            catch (Exception)
            {
            }
            return null;
        }

    }
}
