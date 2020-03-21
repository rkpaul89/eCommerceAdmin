using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace eCommerceAdmin.Models.Products
{
    public class product
    {
        [Key]
        public int productID { get; set; }
        [StringLength(50)]
        [Required]
        public string productSKU { get; set; }
        [StringLength(100)]
        [Required]
        public string productName { get; set; }
        [Required]
        public decimal productPrice { get; set; }
        public float productWeight { get; set; }
        [StringLength(250)]
        public string productCartDesc { get; set; }
        [StringLength(1000)]
        public string productShortDesc { get; set; }
        public string productLongDesc { get; set; }
        [StringLength(100)]
        public string productThumb { get; set; }
        [StringLength(100)]
        public string productImage { get; set; }
        [Required]
        public productCategory productCategoryID { get; set; }
        [Required]
        public decimal productStock { get; set; }

        public bool productLive { get; set; } = true;
        public bool productUnlimited { get; set; } = false;
        [StringLength(250)]
        public string productLocation { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        DateTime productInsertionDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        DateTime productUpdateDate { get; set; }
    }
}