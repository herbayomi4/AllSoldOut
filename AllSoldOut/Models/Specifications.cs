using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class Specifications
    {
        [Key]
        public int productId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Launch Date")]
        public DateTime launchDate { get; set; }

        [Display(Name = "Body Dimension")]
        public string bodyDimension { get; set; }

        [Display(Name = "Body Weight in grams")]
        public string bodyWeight { get; set; }

        [Display(Name = "Display Resolution in pixels")]
        public string displayResolution { get; set; }

        [Display(Name = "Display Size in inches")]
        public double displaySize { get; set; }

        [Display(Name = "Operating System")]
        public string platformOS { get; set; }

        [Display(Name = "RAM in Gigabytes (GB)")]
        public double ram { get; set; }

        [Display(Name = "Internal Memory in Gigabytes (GB)")]
        public double internalMemory { get; set; }

        [Display(Name = "Camera Resolution  in Megapixels (MP)")]
        public double camera { get; set; }

        [Display(Name = "Battery Standyby Time in Hours")]
        public double batteryStandbyTime { get; set; }

        //[Display(Name = "USB Type")]
        //public string usb { get; set; }
    }
}
