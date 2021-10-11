using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class Customer
    {
        public int customerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First Name length can't be more than 50.")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last Name length can't be more than 50.")]
        public string lastName { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        [Remote (action: "VerifyEmail", controller: "Validations")]
        public string email { get; set; }

        [Phone]
        [Display(Name = "Phone Contact")]
        public int contact { get; set; }

        [Display(Name = "Delivery Address")]
        [StringLength(50, ErrorMessage = "Last Name length can't be more than 50.")]
        public string address { get; set; }

        [Display(Name = "Local Government Area")]
        public string lga { get; set; }

    }
}
