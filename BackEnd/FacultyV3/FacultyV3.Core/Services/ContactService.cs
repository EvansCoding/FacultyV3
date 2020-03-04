using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacultyV3.Core.Services
{
    public class ContactService : IContactService
    {
        private IDataContext context;

        public ContactService(IDataContext context)
        {
            this.context = context;
        }

        public Contact GetContactByID(string Id)
        {
            try
            {
                return context.Contacts.Where(x => x.Id == new Guid(Id)).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public List<Contact> GetContacts()
        {
            try
            {
                return context.Contacts.OrderBy(x => x.Meta_Name)
                    .Select(x => x).ToList();
            }
            catch (Exception)
            {

            }
            return null;
        }
    }
}
