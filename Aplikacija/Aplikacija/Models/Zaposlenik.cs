using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplikacija.Models
{
    public class Zaposlenik
    {
        [Key]
        public int IdZaposlenik { get; set; }

        [Required(ErrorMessage = "Obavezan unos!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Obavezan unos!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Obavezan unos!")]
        [Display(Name = "Korisničko ime")]
        public string KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Obavezan unos!")]
        [Display(Name = "Lozinka")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}