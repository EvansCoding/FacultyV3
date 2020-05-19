using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Utilities;
using System;
using System.Collections.Generic;

namespace FacultyV3.Core.Models.Entities
{
    public class Category_News : IBaseEntity
    {
        public Category_News()
        {
            Id = GuidComb.GenerateComb();
        }

        public Guid Id { get; set; }
        public string Meta_Name { get; set; }
        public string Meta_Value { get; set; }
        public bool Block { get; set; }
        public int Serial { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }

        public virtual Category_News Parent { get; set; }
        public virtual IList<Category_News> Children { get; set; }
        public IList<Detail_News> Detail_Newss { get; set; }
    }
}
