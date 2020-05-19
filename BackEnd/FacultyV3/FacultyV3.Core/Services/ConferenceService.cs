using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacultyV3.Core.Services
{
    public class ConferenceService : IConferenceService
    {
        private IDataContext context;

        public ConferenceService(IDataContext context)
        {
            this.context = context;
        }

        public List<Conference> GetConferencesOrderBySerial(int amount)
        {
            try
            {
                var model = context.Conferences.OrderByDescending(x => x.Update_At).ToList();

                var data = model.OrderByDescending(x => x.Serial).Select(x => x).Take(amount).ToList();
                return data;
            }
            catch (Exception)
            {

            }
            return null;
        }

        public List<Conference> GetConferences()
        {
            try
            {
                return context.Conferences
                    .Select(x => x).ToList();
            }
            catch (Exception)
            {

            }
            return null;
        }

        public IEnumerable<Conference> PageList(string name, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return context.Conferences.Where(x => x.Title.Contains(name)).OrderBy(x => x.Update_At).ToPagedList(page, pageSize);
            }
            return context.Conferences.OrderBy(x => x.Update_At).ToPagedList(page, pageSize);
        }

        public List<Conference> GetConferencesByName(string name)
        {
            try
            {
                return context.Conferences
                    .Where(x => x.Title == name)
                    .Select(x => x).ToList();
            }
            catch (Exception)
            {

            }
            return null;
        }

        public Conference GetConferenceByName(string name)
        {
            try
            {
                return context.Conferences
                    .Where(x => x.Title == name).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public Conference GetConferenceByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Conferences.Find(ID);
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
