﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albaque.Models
{
    public class Complexite
    {
        public int Id { get; set; }

        [Required]
        public string nom { get; set; }
    }
}