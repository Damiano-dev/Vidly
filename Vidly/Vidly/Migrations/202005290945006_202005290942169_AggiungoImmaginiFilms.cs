namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202005290942169_AggiungoImmaginiFilms : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ImmagineFilms", newName: "ImmaginiFilms");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ImmaginiFilms", newName: "ImmagineFilms");
        }
    }
}
