namespace eCommerceAdmin.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eCommerceAdmin.Models.eCommerceAdminContext>
    {
        // migration command only creates configuration file, database create when we access dbcontext in application or in test
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(eCommerceAdmin.Models.eCommerceAdminContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
