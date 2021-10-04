using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class Product
    {
        public int productId { get; set; }
        public Category category { get; set; }
        public Store store { get; set; }
    }
}
