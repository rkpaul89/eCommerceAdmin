using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace eCommerceAdmin.Models.Products
{
    public class productCategory
    {
        [Key]
        //[Column(name:"categoryID")]
        public int categoryID { get; set; }
        [StringLength(50)]
        public string categoryName { get; set; }
    }
}