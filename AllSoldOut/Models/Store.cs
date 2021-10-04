using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class Store
    {
        public int storeId { get; set; }
        public bool available { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public double productPrice { get; set; }
        public Category category { get; set; }

    }
}
