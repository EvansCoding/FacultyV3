using System.Data.Entity.ModelConfiguration;
using FacultyV3.Core.Models.Entities;

namespace FacultyV3.Core.Data.Mapping
{
    public class About_UsMapping : EntityTypeConfiguration<About_Us>
    {
        public About_UsMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.Content).IsRequired();
            Property(x => x.Url_Image).IsRequired().HasMaxLength(300);
            Property(x => x.Url_Video).IsRequired().HasMaxLength(300);
            Property(x => x.Create_At).IsRequired();
            Property(x => x.Update_At).IsRequired();
        }
    }
}
