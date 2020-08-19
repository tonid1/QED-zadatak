using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Qed.Models.Data_Access
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(): base("KnjigeConnStr")
        {

        }

        public DbSet<Knjiga> Knjige { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}