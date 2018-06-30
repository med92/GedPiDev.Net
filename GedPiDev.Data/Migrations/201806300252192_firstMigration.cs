namespace GedPiDev.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courriers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        objet = c.String(unicode: false),
                        destinataire = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Courriers");
        }
    }
}
