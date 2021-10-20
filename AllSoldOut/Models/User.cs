using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        [Required]
        public string password { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string contact { get; set; }
        public int roleId { get; set; }
    }
}
