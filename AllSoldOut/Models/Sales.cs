using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class Sales
    {
        [Key]
        public int productId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Sales Date")]
        public DateTime salesDate { get; set; }

        [Required]
        [Range(0, 50000.00)]
        [Display(Name = "Sales Price")]
        public double salesPrice { get; set; }

        [Required]
        [Display(Name = "Payment Platform")]
        [StringLength(50, ErrorMessage = "First Name length can't be more than 50.")]
        public string paymentPlatform { get; set; }
        public int customerId { get; set; }

    }
}
