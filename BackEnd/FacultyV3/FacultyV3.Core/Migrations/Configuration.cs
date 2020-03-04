namespace FacultyV3.Core.Migrations
{
    using FacultyV3.Core.Data.Context;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<DataContext>
    {
        private readonly bool _pendingMigrations;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            var migrator = new DbMigrator(this);

            _pendingMigrations = migrator.GetPendingMigrations().Any();

            if (_pendingMigrations)
            {
                migrator.Update();
                Seed(new DataContext());
            }
        }

        protected override void Seed(DataContext context)
        {
            
        }
    }
}
