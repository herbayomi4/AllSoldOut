using AllSoldOut.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.ViewModel
{
    public class PhoneCreateViewModel
    {
        [Key]
        public int productId { get; set; }
        public Product products { get; set; }
        public Specifications specifications { get; set; }

        public List<PhoneMaker> phoneMakers { get; set; }
    }
}
