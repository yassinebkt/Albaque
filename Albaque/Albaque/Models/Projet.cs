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

        [Required]
        public Client client { get; set; }

        [Required]
        public string Nom { get; set; }


        public double Duree { get; set; }


        public double Delai { get; set; }

        [Required]
        public DateTime Date_Debut { get; set; }

        public DateTime Date_Fin { get; set; }

        public virtual ICollection<Chiffrage> chiffrage { get; set; }
    }
}