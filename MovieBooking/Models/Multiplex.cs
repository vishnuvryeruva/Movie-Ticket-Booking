using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieBooking.Models
{
    public class Multiplex
    {
        [Display(Name = "Multiplex ID")]
        [Key]
        public int TId { get; set; }

        [Display(Name = "Multiplex Name")]

        [Required]
        public string TName { get; set; }

        [Display(Name = "MId")]
        public int mid { get; set; }

        [Display(Name = "Location")]
        public string TLoc { get; set; }

        [Display(Name = "Ticket Price")]
        [DataType(DataType.Currency)]
        public double TPrice { get; set; }

        [Display(Name ="Reserve Date")]
        public DateTime MDate { get; set; }

        public Movie Movie { get; set; }
    }
}