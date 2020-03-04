using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Utilities;
using System;
using System.Collections.Generic;

namespace FacultyV3.Core.Models.Entities
{
    public class Account : IBaseEntity
    {
        public Account()
        {
            Id = GuidComb.GenerateComb();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }

        public IList<Detail_News> Detail_Newss { get; set; }
        public IList<Detail_Menu> Detail_Menus { get; set; }
    }
}
