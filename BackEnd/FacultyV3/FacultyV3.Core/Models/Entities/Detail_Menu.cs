using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Utilities;
using System;

namespace FacultyV3.Core.Models.Entities
{
    public class Detail_Menu : IBaseEntity
    {
        public Detail_Menu()
        {
            Id = GuidComb.GenerateComb();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Serial { get; set; }
        public bool Status { get; set; }
        public string Url_Image { get; set; }
        public string Url_Video { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }

        public Account Account { get; set; }
        public Category_Menu Category_Menu { get; set; }
    }
}
