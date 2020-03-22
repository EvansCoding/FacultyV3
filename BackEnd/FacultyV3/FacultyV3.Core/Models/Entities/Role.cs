using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyV3.Core.Models.Entities
{
    public class Role : IBaseEntity
    {
        public Role()
        {
            Id = GuidComb.GenerateComb();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public IList<Account> Accounts { get; set; }
    }
}
