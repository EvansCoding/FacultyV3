using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Utilities;
using System;

namespace FacultyV3.Core.Models.Entities
{
    public class Ads : IBaseEntity
    {
        public Ads()
        {
            Id = GuidComb.GenerateComb();
        }

        public Guid Id { get; set; }
        public string Url_Image { get; set; }
        public string Url_Link { get; set; }
        public bool Status { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}
