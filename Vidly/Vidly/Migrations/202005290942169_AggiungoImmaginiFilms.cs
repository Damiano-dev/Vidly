namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiungoImmaginiFilms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImmagineFilms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomeFIle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImmagineFilms");
        }
    }
}
