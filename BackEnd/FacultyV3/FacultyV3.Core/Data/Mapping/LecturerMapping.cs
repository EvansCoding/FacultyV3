using System.Data.Entity.ModelConfiguration;
using FacultyV3.Core.Models.Entities;

namespace FacultyV3.Core.Data.Mapping
{
    public class LecturerMapping : EntityTypeConfiguration<Lecturer>
    {
        public LecturerMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.FullName).IsRequired().HasMaxLength(100);
            Property(x => x.Degree).IsRequired().HasMaxLength(100);
            Property(x => x.Url_Image).IsRequired().HasMaxLength(200);
            Property(x => x.Url_Facebook).IsRequired().HasMaxLength(200);
            Property(x => x.Phone).IsRequired().HasMaxLength(12);
            Property(x => x.Email).IsRequired().HasMaxLength(100);
            Property(x => x.Serial).IsRequired();
            Property(x => x.Position).IsOptional();
            Property(x => x.Academic_Rank).IsOptional();
            Property(x => x.Specialized).IsOptional();
            Property(x => x.Title).IsOptional();
            Property(x => x.Native_Land).IsOptional();
            Property(x => x.Url_Scientific_Works).IsOptional();
            Property(x => x.Specialized_Research).IsOptional();
            Property(x => x.Teaching).IsOptional();
            Property(x => x.Create_At).IsRequired();
            Property(x => x.Update_At).IsRequired();

            HasMany(x => x.Training_Processes)
                .WithOptional(x => x.Lecturer)
                .Map(x => x.MapKey("LecturerID"))
                .WillCascadeOnDelete(true);
        }
    }
}
