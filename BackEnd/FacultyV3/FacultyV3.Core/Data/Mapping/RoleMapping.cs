using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using FacultyV3.Core.Models.Entities;

namespace FacultyV3.Core.Data.Mapping
{
    public class RoleMapping : EntityTypeConfiguration<Role>
    {
        public RoleMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.Name).IsRequired();

            HasMany(x => x.Accounts)
                .WithOptional(x => x.Role)
                .Map(x => x.MapKey("Role_ID"))
                .WillCascadeOnDelete(false);
        }
    }
}
