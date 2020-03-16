using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using FacultyV3.Core.Models.Entities;
namespace FacultyV3.Core.Data.Mapping
{
    public class Training_ProcessMapping : EntityTypeConfiguration<Training_Process>
    {
        public Training_ProcessMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.Degree).IsOptional();
            Property(x => x.Graduation_Year).IsOptional();
            Property(x => x.Graduation_School).IsOptional();
            Property(x => x.Graduation_Specialized).IsOptional();
        }
    }
}
