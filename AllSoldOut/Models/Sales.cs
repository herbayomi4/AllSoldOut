using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class Sales
    {
        [ForeignKey("Store")]
        public int salesId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Sales Date")]
        public DateTime saleDate { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First Name length can't be more than 50.")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last Name length can't be more than 50.")]
        public string lastName { get; set; }

        [EmailAddress]
        [Remote (action: "VerifyEmail", controller: "Validations")]
        public string email { get; set; }

        [Phone]
        public int contact { get; set; }

    }
}
