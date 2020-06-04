namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreazioneRelazioneClientiFilms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DataAffitto = c.DateTime(nullable: false),
                        DataRestituzione = c.DateTime(),
                        cliente_Id = c.Int(nullable: false),
                        film_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clienti", t => t.cliente_Id, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.film_Id, cascadeDelete: true)
                .Index(t => t.cliente_Id)
                .Index(t => t.film_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "film_Id", "dbo.Films");
            DropForeignKey("dbo.Rentals", "cliente_Id", "dbo.Clienti");
            DropIndex("dbo.Rentals", new[] { "film_Id" });
            DropIndex("dbo.Rentals", new[] { "cliente_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
