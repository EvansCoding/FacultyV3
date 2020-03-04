using FacultyV3.Core.Models.Entities;
using System.Collections.Generic;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface IContactService
    {
        Contact GetContactByID(string Id);
        List<Contact> GetContacts();
    }
}
