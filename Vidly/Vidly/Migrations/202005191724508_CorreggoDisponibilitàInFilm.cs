namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorreggoDisponibilitàInFilm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Disponibilità", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Films", "Disponibilità", c => c.String(nullable: false));
        }
    }
}
