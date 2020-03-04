using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacultyV3.Core.Services
{
    public class LecturerService : ILecturerService
    {
        private IDataContext context;

        public LecturerService(IDataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Lecturer> PageList(string name, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return context.Lecturers.Where(x => x.FullName.Contains(name)).OrderByDescending(x => new { x.Serial, x.Update_At }).ToPagedList(page, pageSize);
            }
            return context.Lecturers.OrderByDescending(x => new { x.Serial, x.Update_At }).ToPagedList(page, pageSize);
        }

        public Lecturer GetLecturerByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Lecturers.Find(ID);
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
