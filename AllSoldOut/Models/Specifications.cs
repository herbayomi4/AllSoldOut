using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class Specifications
    {
        public int productID { get; set; }

        public string network { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Launch Date")]
        public DateTime launchDate { get; set; }

        [Display(Name = "Body Dimension")]
        public string bodyDimension { get; set; }

        [Display(Name = "Body Weight")]
        public string bodyWeight { get; set; }

        [Display(Name = "Display Resolution")]
        public string displayResolution { get; set; }

        [Display(Name = "Display Size")]
        public string displaySize { get; set; }

        [Display(Name = "Operating System")]
        public string platformOS { get; set; }

        [Display(Name = "RAM")]
        public bool ram { get; set; }

        [Display(Name = "Internal Memory")]
        public string internalMemory { get; set; }

        [Display(Name = "Camera Resolution")]
        public string camera { get; set; }

        [Display(Name = "Battery Standyby Time")]
        public string batteryStandbyTime { get; set; }

        [Display(Name = "USB Type")]
        public string usb { get; set; }
    }
}
