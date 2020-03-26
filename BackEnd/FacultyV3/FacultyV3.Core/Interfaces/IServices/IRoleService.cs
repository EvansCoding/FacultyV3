using FacultyV3.Core.Models.Entities;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface IRoleService
    {
        Role GetRoleByID(string id);
    }
}
