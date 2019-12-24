using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HaberBursa.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Context { get; set; }
        public int Rating { get; set; }
        [ForeignKey("NewsID")]
        public virtual News News { get; set; }
        [ForeignKey("WriterID")]
        public virtual Writer Writer { get; set; }
        
        

    }
}
