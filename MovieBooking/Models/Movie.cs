using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieBooking.Models
{
    public class Movie
    {
        [Key]
        [Display(Name = "Movie Id")]
        public int MId { get; set; }

        [Required]

        [Display(Name = "Movie Name")]
        public string MName { get; set; }

        [Display(Name = "Rating")]
        public int MRate { get; set; }

        [Display(Name ="City")]
        public int MLoc { get; set; }

        [ForeignKey("mid")]
        public ICollection<Multiplex> Multiplices { get; set; }


    }
}