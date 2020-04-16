using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Threading.Tasks;
using eCommerceAdmin.Models;
using eCommerceAdmin.Models.Products;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace eCommerceAdmin.Controllers.Product
{
    public class productController : ApiController
    {
        IECommerceAdminContext db=new eCommerceAdminContext();
        public productController(IECommerceAdminContext context)
        {
            db = context;
        }
        [ResponseType(typeof(product))]
        public async Task<IHttpActionResult> GetProducts()
        {
            try
            {
                List<product> products = await db.products.ToListAsync();
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            
        }

        [ResponseType(typeof(product))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            product product = await db.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id,product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != product.productID)
            {
                return BadRequest();
            }
            db.MarkAsModified<product>(product);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostProduct(product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.products.Add(product);
            await db.SaveChangesAsync();
            return Ok();
        }
        
        [ResponseType(typeof(product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            product product = await db.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            db.products.Remove(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }
        private bool productExist(int id)
        {
            return db.products.Count(e=>e.productID==id)>0;
        }
    }
}
