using AllSoldOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.ViewModel
{
    public class SalesDetailsViewModel
    {
        public Store store { get; set; }
        public Sales sales { get; set; }
        public  int daysOnHold { get; set; }
    }
}
