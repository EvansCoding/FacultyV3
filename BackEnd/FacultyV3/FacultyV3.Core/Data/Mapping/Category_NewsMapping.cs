using System.Data.Entity.ModelConfiguration;
using FacultyV3.Core.Models.Entities;

namespace FacultyV3.Core.Data.Mapping
{
    public class Category_NewsMapping : EntityTypeConfiguration<Category_News> 
    {
        public Category_NewsMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.Meta_Name).IsRequired().HasMaxLength(200);
            Property(x => x.Meta_Value).IsRequired().HasMaxLength(200);
            Property(x => x.Serial).IsRequired();
            Property(x => x.Block).IsRequired();
            Property(x => x.Create_At).IsRequired();
            Property(x => x.Update_At).IsRequired();

            HasMany(x => x.Detail_Newss)
                .WithRequired(x => x.Category_News)
                .Map(x => x.MapKey("Category_News_Id"))
                .WillCascadeOnDelete(true);

            HasOptional(x => x.Parent)
                .WithMany(x => x.Children)
                .Map(x => x.MapKey("Parent_Id"))
                .WillCascadeOnDelete(false);
        }
    }
}
