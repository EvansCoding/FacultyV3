using System.Data.Entity.ModelConfiguration;
using FacultyV3.Core.Models.Entities;

namespace FacultyV3.Core.Data.Mapping
{
    public class ConferenceMapping : EntityTypeConfiguration<Conference>
    {
        public ConferenceMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.Title).IsRequired().HasMaxLength(300);
            Property(x => x.Url_Image).IsRequired().HasMaxLength(300);
            Property(x => x.Url_Link).IsOptional().HasMaxLength(300);
            Property(x => x.Serial).IsRequired();
            Property(x => x.Create_At).IsRequired();
            Property(x => x.Update_At).IsRequired();
        }
    }
}
