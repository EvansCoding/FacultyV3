using FacultyV3.Core.Models.Entities;
using System.Collections.Generic;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface IConfirgurationService
    {
        Confirguration GetConfirgurationByID(string id);
        Confirguration GetConfirgurationByName(string name);
        List<Confirguration> GetConfirgurations();
    }
}
