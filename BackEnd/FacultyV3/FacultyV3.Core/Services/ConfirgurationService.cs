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
    public class ConfirgurationService : IConfirgurationService
    {
        private IDataContext context;
        public ConfirgurationService(IDataContext context)
        {
            this.context = context;
        }

        public Confirguration GetConfirgurationByName(string name)
        {
            try
            {
                return context.Confirgurations.Where(x => x.Meta_Name == name && x.Meta_Value != null).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public Confirguration GetConfirgurationByID(string id)
        {
            try
            {
                return context.Confirgurations.Where(x => x.Id == new Guid(id)).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public List<Confirguration> GetConfirgurations()
        {
            try
            {
                return context.Confirgurations.Select(x => x).ToList();
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
