using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using eCommerceAdmin.Models.Products;
using eCommerceAdmin.Models;
using System.Web;
using System.Web.Mvc;
namespace eCommerceAdmin.Controllers.Product
{
    public class productCategoriesController : ApiController
    {
        private IECommerceAdminContext db = new eCommerceAdminContext();

        // GET: api/productCategories

        //public IQueryable<productCategory> GetproductCategories()
        //{
        //    return db.productCategories;
        //}

        public productCategoriesController()
        {

        }
        public productCategoriesController(IECommerceAdminContext context)
        {
            db = context;
        }

        [ResponseType(typeof(productCategory))]
        public async Task<IHttpActionResult> GetproductCategories()
        {
            List<productCategory> results = await db.productCategories.ToListAsync();
            return Ok(results);
        }
        // GET: api/productCategories/5
        [ResponseType(typeof(productCategory))]
        public async Task<IHttpActionResult> GetproductCategory(int id)
        {
            productCategory productCategory = await db.productCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return Ok(productCategory);
        }

        // PUT: api/productCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutproductCategory(int id, productCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productCategory.categoryID)
            {
                return BadRequest();
            }

            //db.Entry(productCategory).State = EntityState.Modified;
            db.MarkAsModified<productCategory>(productCategory);

            try
            {
                await db.SaveChangesAsync();
                //await db.SaveAsChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productCategoryExists(id))
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

        // POST: api/productCategories
        [ResponseType(typeof(productCategory))]
        public async Task<IHttpActionResult> PostproductCategory(productCategory productCategory)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.productCategories.Add(productCategory);
            await db.SaveChangesAsync();
            //await db.SaveAsChangesAsync();
            // if you POST an order item for instance, you might return a route like 'api/order/11' (11 being the id of the order obviously
            //return CreatedAtRoute("DefaultApi", new { id = productCategory.categoryID }, productCategory);
            return Ok();
        }

        // DELETE: api/productCategories/5
        [ResponseType(typeof(productCategory))]
        public async Task<IHttpActionResult> DeleteproductCategory(int id)
        {
            productCategory productCategory = await db.productCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            db.productCategories.Remove(productCategory);
            await db.SaveChangesAsync();
            //await db.SaveAsChangesAsync();
            return Ok(productCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool productCategoryExists(int id)
        {
            return db.productCategories.Count(e => e.categoryID == id) > 0;
        }
    }
}