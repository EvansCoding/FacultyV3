using FacultyV3.Core.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FacultyV3.Core.Data.Mapping
{
    public class AdsMapping : EntityTypeConfiguration<Ads>
    {
        public AdsMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.Url_Image).IsRequired();
            Property(x => x.Url_Link).IsOptional();
            Property(x => x.Status).IsRequired();
            Property(x => x.Create_At).IsRequired();
            Property(x => x.Update_At).IsRequired();
        }
    }
}
