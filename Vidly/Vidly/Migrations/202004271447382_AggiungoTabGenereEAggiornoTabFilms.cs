namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiungoTabGenereEAggiornoTabFilms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Generi",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Films", "NumeroInStock", c => c.Int(nullable: true));
            AddColumn("dbo.Films", "DataInserimentoInDatabase", c => c.DateTime(nullable: true));
            AddColumn("dbo.Films", "ReleaseDate", c => c.DateTime(nullable: true));
            AddColumn("dbo.Films", "Idgenere", c => c.Byte(nullable: false));
            AlterColumn("dbo.Films", "Nome", c => c.String(nullable: false));
            CreateIndex("dbo.Films", "Idgenere");
            AddForeignKey("dbo.Films", "Idgenere", "dbo.Generi", "Id", cascadeDelete: true);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "Idgenere", "dbo.Generi");
            DropIndex("dbo.Films", new[] { "Idgenere" });
            AlterColumn("dbo.Films", "Nome", c => c.String());
            DropColumn("dbo.Films", "Idgenere");
            DropColumn("dbo.Films", "ReleaseDate");
            DropColumn("dbo.Films", "DataInserimentoInDatabase");
            DropColumn("dbo.Films", "NumeroInStock");
            DropTable("dbo.Generi");
        }
    }
}
