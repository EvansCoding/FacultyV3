using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using System;
using System.Linq;

namespace FacultyV3.Core.Services
{
    public class RoleService : IRoleService
    {
        private IDataContext context;
        public RoleService(IDataContext context)
        {
            this.context = context;
        }


        public Role GetRoleByID(string id)
        {
            try
            {
                return context.Roles.Where(x => x.Id == new Guid(id)).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }

    }
}
