using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Qed.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public DateTime PocetakBookinga { get; set; }
        public DateTime KrajBookinga { get; set; }
        public int KnjigaId { get; set; }
        public Knjiga Knjiga { get; set; }
        public Booking()
        {
            PocetakBookinga = DateTime.Now;
            KrajBookinga = DateTime.Now.AddDays(7);
        }
    }
}