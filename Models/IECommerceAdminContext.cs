using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace eCommerceAdmin.Models
{
    public interface IECommerceAdminContext:IDisposable
    {
        DbSet<Products.productCategory> productCategories { get; }
        Task<int> SaveChangesAsync();
        void MarkAsModified<T>(T item);
    }
}
