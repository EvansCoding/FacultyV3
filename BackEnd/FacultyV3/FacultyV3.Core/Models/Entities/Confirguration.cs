using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Utilities;
using System;

namespace FacultyV3.Core.Models.Entities
{
    public class Confirguration : IBaseEntity
    {
        public Confirguration()
        {
            Id = GuidComb.GenerateComb();
        }

        public Guid Id { get; set; }
        public string Meta_Name { get; set; }
        public string Meta_Value { get; set; }
    }
}
