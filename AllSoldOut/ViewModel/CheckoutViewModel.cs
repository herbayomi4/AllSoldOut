using AllSoldOut.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.ViewModel
{
    public class CheckoutViewModel
    {
        [Key]
        public int orderId { get; set; }
        public Customer customer { get; set; }
        public Cart cart { get; set; }
        public User user { get; set; }
    }
}
