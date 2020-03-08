using FacultyV3.Core.Models.Entities;
using System.Collections.Generic;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface IBannerService
    {
        List<Banner> GetBanners();
        List<Banner> GetBannersByName(string name);
        Banner GetBannerByName(string name);
        Banner GetBannerByID(string id);
        IEnumerable<Banner> PageList(string name, int page, int pageSize);
        List<Banner> GetBannersOrderBySerial(int amount);
    }
}
