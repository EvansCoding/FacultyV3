﻿using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Utilities;
using System;
using System.Collections.Generic;

namespace FacultyV3.Core.Models.Entities
{
    public class Category_Menu : IBaseEntity
    {
        public Category_Menu()
        {
            Id = GuidComb.GenerateComb();
        }

        public Guid Id { get; set; }
        public string Meta_Name { get; set; }
        public string Meta_Value { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }

        public virtual Category_Menu Parent { get; set; }
        public virtual IList<Category_Menu> Children { get; set; }

        public IList<Detail_Menu> Detail_Menus { get; set; }
    }
}
