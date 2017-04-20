using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albaque.Models
{
    public class Technologie
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }
    }
}