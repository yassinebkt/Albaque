using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Albaque.Models
{
    public class ChiffrageDBContext : DbContext
    {
        public ChiffrageDBContext()
            : base(@"Persist Security Info=False;Integrated Security=true;Initial Catalog=Albaque;server=PC954")
        {

        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Complexite> Complexites { get; set; }
        public DbSet<Technologie> Technologies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Tache> Taches { get; set; }
        
        public DbSet<Chiffrage> Chiffrages { get; set; }
        
    }
}