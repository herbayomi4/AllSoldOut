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
        public int salesId { get; set; }
        public int productId { get; set; }
        public DateTime salesDate { get; set; }
        public decimal unitPrice { get; set; }
        public int quantity { get; set; }
        public decimal salesPrice { get; set; }
        public string? paymentPlatform { get; set; }
        public int customerId { get; set; }

    }
}
