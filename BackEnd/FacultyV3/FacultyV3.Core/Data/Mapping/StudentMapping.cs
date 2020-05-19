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
            Property(x => x.Content).IsOptional();
            Property(x => x.Course).IsOptional();
            Property(x => x.Major).IsOptional();
            Property(x => x.Graduation_Year).IsOptional();
            Property(x => x.Current_Job).IsOptional();
            Property(x => x.Work_Place).IsOptional();
            Property(x => x.Serial).IsRequired();
            Property(x => x.Create_At).IsRequired();
            Property(x => x.Update_At).IsRequired();
        }
    }
}
