using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORE.Models
{
    public class SType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sale Type")]
        public string Type { get; set; }
    }
}
