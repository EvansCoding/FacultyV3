using System.Data.Entity.ModelConfiguration;
using FacultyV3.Core.Models.Entities;

namespace FacultyV3.Core.Data.Mapping
{
    public class AccountMapping : EntityTypeConfiguration<Account>
    {
        public AccountMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Email).IsRequired().HasMaxLength(100);
            Property(x => x.Password).IsRequired().HasMaxLength(256);
            Property(x => x.FullName).IsRequired().HasMaxLength(200);
            Property(x => x.Create_At).IsRequired();
            Property(x => x.Update_At).IsRequired();

            HasMany(x => x.Detail_Menus)
                .WithRequired(x => x.Account)
                .Map(x => x.MapKey("Account_ID"))
                .WillCascadeOnDelete(false);

            HasMany(x => x.Detail_Newss)
                .WithRequired(x => x.Account)
                .Map(x => x.MapKey("Account_ID"))
                .WillCascadeOnDelete(false);
        }
    }
}
