using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        public int productId { get; set; }

        public bool available { get; set; } = true;

        [Display(Name = "Category")]
        public string productCategory { get; set; }

        [Required] 
        [Display(Name = "Name")] 
        [StringLength(50, ErrorMessage = "Product Name length can't be more than 50.")] 
        public string productName { get; set; }

        [Required]
        [Range(0, 50000.00)]
        [Display(Name = "Price in $")]
        public decimal productPrice { get; set; }

        [Display(Name ="Color")]
        public string productColor { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(150, ErrorMessage = "Product Description length can't be more than 150.")]
        public string productDescription { get; set; }

        [Display(Name = "Image")]
        public string? productImageName { get; set; }
                                                                         
        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime dateCreated { get; set; }

        [Display(Name = "Stock Added")]
        public int inStock { get; set; }

        [Display(Name = "Quantity Available")]
        public int quantityAvailable { get; set; }

    }
}
