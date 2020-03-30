using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace eCommerceAdmin.Models.Products
{
    public partial class productCategory
    {
        [Key]
        public int categoryID { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Category name is required")]
        [StringLength(50)]
        public string categoryName { get; set; }
    }
}