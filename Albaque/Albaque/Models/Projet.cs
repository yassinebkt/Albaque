using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Albaque.Models
{
    public class Projet
    {
        public int Id { get; set; }

        [Display(Name = "Nom du client")]
        [Required]
        public int ClientId { get; set; }

        [Required]
        public string Nom { get; set; }

        public double Duree { get; set; }

        public double Delai { get; set; }

        [Required]
        public DateTime Date_Debut { get; set; }

        public DateTime Date_Fin { get; set; }

        public virtual Client client { get; set; }

        public virtual ICollection<Chiffrage> chiffrage { get; set; }
    }
}