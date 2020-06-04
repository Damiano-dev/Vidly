namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiungoMappingImmaginiFilms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MappingImmaginiFilms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageNumber = c.Int(nullable: false),
                        FIlmID = c.Int(nullable: false),
                        ImmagineFilmID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Films", t => t.FIlmID, cascadeDelete: true)
                .ForeignKey("dbo.ImmaginiFilms", t => t.ImmagineFilmID, cascadeDelete: true)
                .Index(t => t.FIlmID)
                .Index(t => t.ImmagineFilmID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MappingImmaginiFilms", "ImmagineFilmID", "dbo.ImmaginiFilms");
            DropForeignKey("dbo.MappingImmaginiFilms", "FIlmID", "dbo.Films");
            DropIndex("dbo.MappingImmaginiFilms", new[] { "ImmagineFilmID" });
            DropIndex("dbo.MappingImmaginiFilms", new[] { "FIlmID" });
            DropTable("dbo.MappingImmaginiFilms");
        }
    }
}
