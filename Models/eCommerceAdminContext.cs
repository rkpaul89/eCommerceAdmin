using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using eCommerceAdmin.Models.Products;
namespace eCommerceAdmin.Models
{
    public class eCommerceAdminContext:DbContext
    {
        public eCommerceAdminContext():base("name=eCommerceCon")
        {
            //Database.SetInitializer<eCommerceAdminContext>(new CreateDatabaseIfNotExists<eCommerceAdminContext>());
            Database.SetInitializer<eCommerceAdminContext>(new MigrateDatabaseToLatestVersion<eCommerceAdminContext,eCommerceAdmin.Migrations.Configuration>());
        }
        public DbSet<product> products { get; set; }
        public DbSet<productCategory> productCategories { get; set; }
    }
}