using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using FacultyV3.Core.Models.Entities;

namespace FacultyV3.Core.Data.Mapping
{
    public class ConfirguationMapping : EntityTypeConfiguration<Confirguration>
    {
        public ConfirguationMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.Meta_Name).IsRequired();
            Property(x => x.Meta_Value).IsOptional();
        }
    }
}
