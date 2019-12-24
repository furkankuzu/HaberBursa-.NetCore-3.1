using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HaberBursa.Models
{
    public class News
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Headline { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public string Explanation { get; set; }
        [Required]
        public string Content { get; set; }
        [Display(Name = "Start Date")]

        public DateTime StartDate { get; set; }
        public string Video { get; set; }
        public int Rating { get; set; }
        [ForeignKey("WriterID")]
        public virtual Writer Writer { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }


    }
}
