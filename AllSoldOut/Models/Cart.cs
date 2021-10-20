using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class Cart
    {
        public int cartId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public string productImageName { get; set; }
        public decimal productPrice { get; set; }

        [Required]
        public int quantity { get; set; } 
        public decimal total { get; set; }
    }


}
