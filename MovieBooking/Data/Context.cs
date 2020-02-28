using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieBooking.Models;
using System.Data.Entity;

namespace MovieBooking.Data
{
    public class Context:DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Multiplex> Multiplices { get; set; }
    }
}