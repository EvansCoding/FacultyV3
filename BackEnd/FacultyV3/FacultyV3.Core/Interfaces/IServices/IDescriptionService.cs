using FacultyV3.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface IDescriptionService
    {
        List<Service> GetServices();
        Service GetServiceByID(string id);
    }
}
