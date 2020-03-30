using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using eCommerceAdmin.Models.Products;
using System.Threading.Tasks;
namespace eCommerceAdmin.Models
{
    public class eCommerceAdminContext:DbContext,IECommerceAdminContext
    {
        public eCommerceAdminContext():base("name=eCommerceCon")
        {
            //Database.SetInitializer<eCommerceAdminContext>(new DropCreateDatabaseAlways<eCommerceAdminContext>());
            Database.SetInitializer<eCommerceAdminContext>(new MigrateDatabaseToLatestVersion<eCommerceAdminContext,eCommerceAdmin.Migrations.Configuration>());
        }

        public DbSet<product> products { get; set; }
        public DbSet<productCategory> productCategories { get; set; }

        public void MarkAsModified<T>(T item)
        {
            Entry(item).State = EntityState.Modified;
        }

        //public Task<int> SaveAsChangesAsync()
        //{
        //   Task<int> f= this.SaveChangesAsync();
        //   return f;
        //}
    }
}