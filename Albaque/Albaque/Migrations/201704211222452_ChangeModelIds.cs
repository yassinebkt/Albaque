namespace Albaque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModelIds : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Chiffrage_Tache", name: "chiffrage_Id", newName: "ChiffrageId");
            RenameColumn(table: "dbo.Chiffrages", name: "projet_Id", newName: "ProjetId");
            RenameColumn(table: "dbo.Chiffrages", name: "utilisateur_Id", newName: "UtilisateurId");
            RenameColumn(table: "dbo.Chiffrage_Tache", name: "tache_Id", newName: "TacheId");
            RenameColumn(table: "dbo.Taches", name: "categorie_Id", newName: "CategorieId");
            RenameColumn(table: "dbo.Taches", name: "complexite_Id", newName: "ComplexiteId");
            RenameColumn(table: "dbo.Taches", name: "technologie_Id", newName: "TechnologieId");
            RenameColumn(table: "dbo.Projets", name: "client_Id", newName: "ClientId");
            RenameIndex(table: "dbo.Chiffrages", name: "IX_projet_Id", newName: "IX_ProjetId");
            RenameIndex(table: "dbo.Chiffrages", name: "IX_utilisateur_Id", newName: "IX_UtilisateurId");
            RenameIndex(table: "dbo.Chiffrage_Tache", name: "IX_chiffrage_Id", newName: "IX_ChiffrageId");
            RenameIndex(table: "dbo.Chiffrage_Tache", name: "IX_tache_Id", newName: "IX_TacheId");
            RenameIndex(table: "dbo.Taches", name: "IX_categorie_Id", newName: "IX_CategorieId");
            RenameIndex(table: "dbo.Taches", name: "IX_complexite_Id", newName: "IX_ComplexiteId");
            RenameIndex(table: "dbo.Taches", name: "IX_technologie_Id", newName: "IX_TechnologieId");
            RenameIndex(table: "dbo.Projets", name: "IX_client_Id", newName: "IX_ClientId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Projets", name: "IX_ClientId", newName: "IX_client_Id");
            RenameIndex(table: "dbo.Taches", name: "IX_TechnologieId", newName: "IX_technologie_Id");
            RenameIndex(table: "dbo.Taches", name: "IX_ComplexiteId", newName: "IX_complexite_Id");
            RenameIndex(table: "dbo.Taches", name: "IX_CategorieId", newName: "IX_categorie_Id");
            RenameIndex(table: "dbo.Chiffrage_Tache", name: "IX_TacheId", newName: "IX_tache_Id");
            RenameIndex(table: "dbo.Chiffrage_Tache", name: "IX_ChiffrageId", newName: "IX_chiffrage_Id");
            RenameIndex(table: "dbo.Chiffrages", name: "IX_UtilisateurId", newName: "IX_utilisateur_Id");
            RenameIndex(table: "dbo.Chiffrages", name: "IX_ProjetId", newName: "IX_projet_Id");
            RenameColumn(table: "dbo.Projets", name: "ClientId", newName: "client_Id");
            RenameColumn(table: "dbo.Taches", name: "TechnologieId", newName: "technologie_Id");
            RenameColumn(table: "dbo.Taches", name: "ComplexiteId", newName: "complexite_Id");
            RenameColumn(table: "dbo.Taches", name: "CategorieId", newName: "categorie_Id");
            RenameColumn(table: "dbo.Chiffrage_Tache", name: "TacheId", newName: "tache_Id");
            RenameColumn(table: "dbo.Chiffrages", name: "UtilisateurId", newName: "utilisateur_Id");
            RenameColumn(table: "dbo.Chiffrages", name: "ProjetId", newName: "projet_Id");
            RenameColumn(table: "dbo.Chiffrage_Tache", name: "ChiffrageId", newName: "chiffrage_Id");
        }
    }
}
