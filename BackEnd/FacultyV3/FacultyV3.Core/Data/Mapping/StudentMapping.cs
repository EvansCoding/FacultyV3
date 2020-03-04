using System.Data.Entity.ModelConfiguration;
using FacultyV3.Core.Models.Entities;

namespace FacultyV3.Core.Data.Mapping
{
    public class StudentMapping : EntityTypeConfiguration<Student>
    {
        public StudentMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.FullName).IsRequired().HasMaxLength(100);
            Property(x => x.Url_Image).IsRequired().HasMaxLength(200);
            Property(x => x.Content).IsRequired().HasMaxLength(200);
            Property(x => x.Serial).IsRequired();
            Property(x => x.Create_At).IsRequired();
            Property(x => x.Update_At).IsRequired();
        }
    }
}
