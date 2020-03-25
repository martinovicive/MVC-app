using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplikacija.Models
{
    public class Predbiljezba
    {
        [Key]
        public int IdPredbiljezba { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Datum upisa")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Obavezan unos!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Obavezan unos!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Obavezan unos!")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Obavezan unos!")]

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obavezan unos!")]
        public string Telefon { get; set; }

        [Display(Name = "Seminar")]
        public int IdSeminar { get; set; }

        [Display(Name = "Obrađeno")]
        public bool Status { get; set; }

        public virtual Seminar Seminar { get; set; }
    }
}