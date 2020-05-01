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

        public bool UpdateTotal()
        {
            try
            {
                var model = context.Confirgurations.Where(x => x.Meta_Name == Constants.Constant.TOTAL_ACCESS).SingleOrDefault();
                long total = long.Parse(model.Meta_Value) + 1;
                model.Meta_Value = total.ToString();
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
