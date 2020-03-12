using FacultyV3.Core.Models.Entities;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface IAdsService
    {
        Ads GetTop();
        Ads GetAdsByID(string Id);
        Ads ShowUI();
    }
}
