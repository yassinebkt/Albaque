using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albaque.Models
{
    public class Tache
    {
        public int Id { get; set; }

        [Required]
        public Categorie categorie { get; set; }

        [Required]
        public Complexite complexite { get; set; }

        [Required]
        public Technologie technologie { get; set; }

        [Required]
        public string nom { get; set; }

        public string description { get; set; }

        public double charge { get; set; }

        public virtual ICollection<Chiffrage_Tache> chiffrageTache { get; set; }
    }
}