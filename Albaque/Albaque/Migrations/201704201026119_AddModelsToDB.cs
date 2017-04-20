namespace Albaque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelsToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Chiffrages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                        version = c.String(),
                        projet_Id = c.Int(nullable: false),
                        utilisateur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projets", t => t.projet_Id, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.utilisateur_Id, cascadeDelete: true)
                .Index(t => t.projet_Id)
                .Index(t => t.utilisateur_Id);
            
            CreateTable(
                "dbo.Chiffrage_Tache",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                        ordre = c.Int(nullable: false),
                        chiffrage_Id = c.Int(nullable: false),
                        tache_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chiffrages", t => t.chiffrage_Id, cascadeDelete: true)
                .ForeignKey("dbo.Taches", t => t.tache_Id, cascadeDelete: true)
                .Index(t => t.chiffrage_Id)
                .Index(t => t.tache_Id);
            
            CreateTable(
                "dbo.Taches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                        description = c.String(),
                        charge = c.Double(nullable: false),
                        categorie_Id = c.Int(nullable: false),
                        complexite_Id = c.Int(nullable: false),
                        technologie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.categorie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Complexites", t => t.complexite_Id, cascadeDelete: true)
                .ForeignKey("dbo.Technologies", t => t.technologie_Id, cascadeDelete: true)
                .Index(t => t.categorie_Id)
                .Index(t => t.complexite_Id)
                .Index(t => t.technologie_Id);
            
            CreateTable(
                "dbo.Complexites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Duree = c.Double(nullable: false),
                        Delai = c.Double(nullable: false),
                        Date_Debut = c.DateTime(nullable: false),
                        Date_Fin = c.DateTime(nullable: false),
                        client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.client_Id, cascadeDelete: true)
                .Index(t => t.client_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                        adresse_Mail = c.String(),
                        numero_Tel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Poste = c.String(),
                        Adresse_Mail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chiffrages", "utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Chiffrages", "projet_Id", "dbo.Projets");
            DropForeignKey("dbo.Projets", "client_Id", "dbo.Clients");
            DropForeignKey("dbo.Chiffrage_Tache", "tache_Id", "dbo.Taches");
            DropForeignKey("dbo.Taches", "technologie_Id", "dbo.Technologies");
            DropForeignKey("dbo.Taches", "complexite_Id", "dbo.Complexites");
            DropForeignKey("dbo.Taches", "categorie_Id", "dbo.Categories");
            DropForeignKey("dbo.Chiffrage_Tache", "chiffrage_Id", "dbo.Chiffrages");
            DropIndex("dbo.Projets", new[] { "client_Id" });
            DropIndex("dbo.Taches", new[] { "technologie_Id" });
            DropIndex("dbo.Taches", new[] { "complexite_Id" });
            DropIndex("dbo.Taches", new[] { "categorie_Id" });
            DropIndex("dbo.Chiffrage_Tache", new[] { "tache_Id" });
            DropIndex("dbo.Chiffrage_Tache", new[] { "chiffrage_Id" });
            DropIndex("dbo.Chiffrages", new[] { "utilisateur_Id" });
            DropIndex("dbo.Chiffrages", new[] { "projet_Id" });
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Clients");
            DropTable("dbo.Projets");
            DropTable("dbo.Technologies");
            DropTable("dbo.Complexites");
            DropTable("dbo.Taches");
            DropTable("dbo.Chiffrage_Tache");
            DropTable("dbo.Chiffrages");
            DropTable("dbo.Categories");
        }
    }
}
