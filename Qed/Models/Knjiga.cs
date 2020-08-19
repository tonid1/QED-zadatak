using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Qed.Models
{
    public class Knjiga
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naslov { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Naklada { get; set; }
        public string DatumDodavanja { get; set; }
        public string Uploader { get; set; }
        public bool Bookirana { get; set; }
        public ICollection<Booking> Booking { get; set; }
        public Knjiga()
        {
            DatumDodavanja = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}