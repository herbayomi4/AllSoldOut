﻿using AllSoldOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.ViewModel
{
    public class SalesDetailsViewModel
    {
        public Phone store { get; set; }
        public Customer customers { get; set; }
        public  int daysOnHold { get; set; }
    }
}
