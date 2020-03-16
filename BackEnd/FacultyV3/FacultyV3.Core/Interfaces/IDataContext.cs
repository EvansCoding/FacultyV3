namespace FacultyV3.Core.Interfaces
{
    using Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading.Tasks;

    public partial interface IDataContext : IDisposable
    {
        DbSet<About_Us> About_Us { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<Banner> Banners { get; set; }
        DbSet<Category_Menu> Category_Menus { get; set; }
        DbSet<Category_News> Category_News { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Count> Counts { get; set; }
        DbSet<Detail_Menu> Detail_Menus { get; set; }
        DbSet<Detail_News> Detail_News { get; set; }
        DbSet<Lecturer> Lecturers { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Stickey> Stickeys { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Video> Videos { get; set; }
        DbSet<Ads> Adss { get; set; }
        DbSet<Training_Process> Training_Processes { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void RollBack();
        DbEntityEntry Entry(Object entity);
    }
}
