using Albaque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Albaque.ViewModels
{
    public class ProjetClientViewModel
    {
        public IEnumerable<Client> clients { get; set; }
        public Projet projet { get; set; }
        public Client newClient { get; set; }
    }
}