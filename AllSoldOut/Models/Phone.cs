using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class Phone
    {
        [Key]
        [Display(Name = "Product ID")]
        public int productId { get; set; }

        public bool available { get; set; } = true;

        [Display(Name = "Product Category")]
        public string productCategory { get; set; }

        [Display(Name = "Product Maker")]
        public string productMaker { get; set; }

        [Required] 
        [Display(Name = "Product Name")] 
        [StringLength(50, ErrorMessage = "Product Name length can't be more than 50.")] 
        public string productName { get; set; }

        [Required]
        [Range(0, 50000.00)]
        [Display(Name = "Product Price")]
        public double productPrice { get; set; }

        [Display(Name ="Phone Color")]
        public string phoneColor { get; set; }

        [Required]
        [Display(Name = "Product Description")]
        [StringLength(150, ErrorMessage = "Product Description length can't be more than 150.")]
        public string productDescription { get; set; }
        public string? productImageName { get; set; }
                                                                         
        [DataType(DataType.Date)]
        [Display(Name = "Date Added to Store")]
        public DateTime dateCreated { get; set; }


    }
}
