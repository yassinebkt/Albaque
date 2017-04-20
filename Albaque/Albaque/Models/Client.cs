using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albaque.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string nom { get; set; }

        public string adresse_Mail { get; set; }

        public string numero_Tel { get; set; }

        public virtual ICollection<Projet> projets { get; set; }
    }
}