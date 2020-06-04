namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiongoDisponibilitàTabFilm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "Disponibilità", c => c.String(nullable: false));
            Sql("Update Films set Disponibilità = NumeroInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "Disponibilità");
        }
    }
}
