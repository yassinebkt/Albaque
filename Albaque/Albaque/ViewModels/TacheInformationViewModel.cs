using Albaque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Albaque.ViewModels
{
    public class TacheInformationViewModel
    {
        public IEnumerable<Categorie> categories { get; set; }
        public IEnumerable<Complexite> complexites { get; set; }
        public IEnumerable<Technologie> technologies { get; set; }
        public Tache tache { get; set; }  
    }
}