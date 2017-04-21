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

        [Display(Name = "Nom d'utilisateur")]
        [Required]
        public string nom { get; set; }

        [Display(Name = "Poste d'utilisateur")]
        public string poste { get; set; }

        [Display(Name = "Addresse mail ")]
        [Required]
        public string adresse_Mail { get; set; }

        
        public virtual ICollection<Chiffrage> chiffrage { get; set; }
    }
}