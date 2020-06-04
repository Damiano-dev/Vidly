namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiungoIlNumeroDiTelefono : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NumeroDiTelefono", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NumeroDiTelefono");
        }
    }
}
