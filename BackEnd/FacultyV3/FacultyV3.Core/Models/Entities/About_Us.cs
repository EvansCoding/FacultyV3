using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Utilities;
using System;

namespace FacultyV3.Core.Models.Entities
{
    public class About_Us : IBaseEntity
    {
        public About_Us()
        {
            Id = GuidComb.GenerateComb();
        }

        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Url_Image { get; set; }
        public string Url_Video { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}
