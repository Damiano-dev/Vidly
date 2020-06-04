namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiungoIlTipoTabAbbonamenti : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abbonamenti", "Tipo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abbonamenti", "Tipo");
        }
    }
}
