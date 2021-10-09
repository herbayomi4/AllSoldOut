using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class Store
    {
        [Key]
        [Display(Name = "Product ID")]
        public int storeId { get; set; }

        public int? salesId { get; set; }

        [Required] 
        [Display(Name = "Product Name")] 
        [StringLength(50, ErrorMessage = "Product Name length can't be more than 50.")] 
        public string productName { get; set; }

        [Display(Name = "Product Category")]
        public string productCategory { get; set; }

        [Required]
        [Display(Name = "Product Description")]
        [StringLength(150, ErrorMessage = "Product Description length can't be more than 150.")]
        public string productDescription { get; set; }

        [Required]
        [Range(0, 50000.00)]
        [Display(Name = "Product Price")]
        public double productPrice { get; set; }

        public string productImageName { get; set; }

        

    }
}
