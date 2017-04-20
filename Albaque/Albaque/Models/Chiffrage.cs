using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albaque.Models
{
    public class Chiffrage
    {
        public int Id { get; set; }

        [Required]
        public Utilisateur utilisateur { get; set; }

        [Required]
        public Projet projet { get; set; }

        [Required]
        public string nom { get; set; }

        public string version { get; set; }

        public virtual ICollection<Chiffrage_Tache> chiffrageTache { get; set; }

    }
}