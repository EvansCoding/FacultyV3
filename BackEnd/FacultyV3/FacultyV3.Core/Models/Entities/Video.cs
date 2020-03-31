using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Utilities;
using System;

namespace FacultyV3.Core.Models.Entities
{
    public class Video : IBaseEntity
    {
        public Video()
        {
            Id = GuidComb.GenerateComb();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Url_Video { get; set; }
        public string Url_Image { get; set; }
        public int  Serial { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }       
    }
}
