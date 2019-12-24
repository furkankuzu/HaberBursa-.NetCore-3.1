using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HaberBursa.Models
{
    public class Writer
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Full Name")]

        [Required]
        public string FullName { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Info { get; set; }
        public string Image { get; set; }
        [Required]
        public string Adress { get; set; }
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
    }
}
