using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class PhoneMaker
    {
        public int makerId { get; set; }
        [Key] public string makerName { get; set; }
        public string makerCategory { get; set; }
    }
}
