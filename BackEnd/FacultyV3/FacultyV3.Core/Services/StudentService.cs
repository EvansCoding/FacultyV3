using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyV3.Core.Services
{
    public class StudentService : IStudentService
    {
        private IDataContext context;

        public StudentService(IDataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Student> PageList(string name, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return context.Students.Where(x => x.FullName.Contains(name)).OrderByDescending(x => new { x.Serial, x.Update_At }).ToPagedList(page, pageSize);
            }
            return context.Students.OrderByDescending(x => new { x.Serial, x.Update_At }).ToPagedList(page, pageSize);
        }

        public Student GetStudentByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Students.Find(ID);
            }
            catch (Exception)
            {
            }
            return null;
        }

        public List<Student> GetStudentOrderBySerial(int amount)
        {
            try
            {
                return context.Students
                    .OrderBy(x => x.Serial)
                    .Select(x => x).Take(amount)
                    .ToList();
            }
            catch (Exception)
            {

            }
            return null;
        }
    }
}
