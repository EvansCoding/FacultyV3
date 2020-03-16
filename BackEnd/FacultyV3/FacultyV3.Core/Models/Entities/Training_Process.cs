using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyV3.Core.Models.Entities
{
    public class Training_Process : IBaseEntity
    {
        public Training_Process()
        {
            Id = GuidComb.GenerateComb();
        }

        public Guid Id { get; set; }
        public string Degree { get; set; }
        public string Graduation_Year { get; set; }
        public string Graduation_School { get; set; }
        public string Graduation_Specialized { get; set; }

        public Lecturer Lecturer { get; set; }
    }
}
