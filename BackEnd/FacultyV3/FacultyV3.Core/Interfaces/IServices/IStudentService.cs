using FacultyV3.Core.Models.Entities;
using System.Collections.Generic;

namespace FacultyV3.Core.Interfaces.IServices
{
    public interface IStudentService
    {
        Student GetStudentByID(string id);
        IEnumerable<Student> PageList(string name, int page, int pageSize);
        List<Student> GetStudentOrderBySerial(int amount);
    }
}
