using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albaque.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        public string Poste { get; set; }

        [Required]
        public string Adresse_Mail { get; set; }

        
        public virtual ICollection<Chiffrage> chiffrage { get; set; }
    }
}