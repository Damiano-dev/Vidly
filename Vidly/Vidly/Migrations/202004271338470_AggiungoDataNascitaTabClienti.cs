namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiungoDataNascitaTabClienti : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clienti", "Data_di_nascita", c => c.DateTime());
           
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clienti", "Data_di_nascita");
        }
    }
}
