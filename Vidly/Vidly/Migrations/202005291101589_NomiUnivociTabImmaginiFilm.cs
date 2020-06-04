namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomiUnivociTabImmaginiFilm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ImmaginiFilms", "NomeFile", c => c.String(maxLength: 100));
            CreateIndex("dbo.ImmaginiFilms", "NomeFile", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.ImmaginiFilms", new[] { "NomeFile" });
            AlterColumn("dbo.ImmaginiFilms", "NomeFile", c => c.String());
        }
    }
}
