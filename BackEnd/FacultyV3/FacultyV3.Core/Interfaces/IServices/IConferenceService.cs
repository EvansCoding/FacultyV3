using FacultyV3.Core.Models.Entities;
using System.Collections.Generic;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface IConferenceService
    {
        List<Conference> GetConferences();
        List<Conference> GetConferencesByName(string name);
        Conference GetConferenceByName(string name);
        Conference GetConferenceByID(string id);
        IEnumerable<Conference> PageList(string name, int page, int pageSize);
        List<Conference> GetConferencesOrderBySerial(int amount);
    }
}
