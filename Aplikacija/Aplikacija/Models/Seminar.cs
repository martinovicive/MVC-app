using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplikacija.Models
{
    public class Seminar
    {
        [Key]
        public int IdSeminar { get; set; }
        [Required(ErrorMessage = "Obavezan unos!")]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        [Required(ErrorMessage = "Obavezan unos!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Datum { get; set; }
        public bool Popunjen { get; set; }

        public virtual ICollection<Predbiljezba> Predbiljezba { get; set; }
    }
}