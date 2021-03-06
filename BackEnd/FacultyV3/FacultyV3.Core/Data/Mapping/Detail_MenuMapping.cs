﻿using System.Data.Entity.ModelConfiguration;
using FacultyV3.Core.Models.Entities;

namespace FacultyV3.Core.Data.Mapping
{
    public class Detail_MenuMapping : EntityTypeConfiguration<Detail_Menu>
    {
        public Detail_MenuMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.Title).IsRequired().HasMaxLength(1024);
            Property(x => x.Description).IsRequired().HasMaxLength(1024);
            Property(x => x.Content).IsRequired();
            Property(x => x.Serial).IsRequired();
            Property(x => x.Status).IsRequired();
            Property(x => x.Block).IsRequired();
            Property(x => x.Url_Image).IsOptional().HasMaxLength(300);
            Property(x => x.Url_Video).IsOptional().HasMaxLength(300);
            Property(x => x.Url_LinkGoogle).IsOptional();
            Property(x => x.Create_At).IsRequired();
            Property(x => x.Update_At).IsRequired();
        }
    }
}
