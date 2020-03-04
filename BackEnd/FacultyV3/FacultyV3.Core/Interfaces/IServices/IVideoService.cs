using FacultyV3.Core.Models.Entities;
using System.Collections.Generic;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface IVideoService
    {
        Video GetVideoByID(string id);
        IEnumerable<Video> PageList(string name, int page, int pageSize);
    }
}
