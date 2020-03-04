using System.Data.Entity.ModelConfiguration;
using FacultyV3.Core.Models.Entities;

namespace FacultyV3.Core.Data.Mapping
{
    public class ServiceMapping :EntityTypeConfiguration<Service>
    {
        public ServiceMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.Meta_Name).IsRequired().HasMaxLength(100);
            Property(x => x.Meta_Value).IsRequired().HasMaxLength(300);
            Property(x => x.Create_At).IsRequired();
            Property(x => x.Update_At).IsRequired();
        }
    }
}
