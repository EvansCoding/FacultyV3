using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Utilities;
using System;

namespace FacultyV3.Core.Models.Entities
{
    public class Lecturer : IBaseEntity
    {
        public Lecturer()
        {
            Id = GuidComb.GenerateComb();
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Degree { get; set; }
        public string Url_Image { get; set; }
        public string Url_Facebook { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Serial { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}
