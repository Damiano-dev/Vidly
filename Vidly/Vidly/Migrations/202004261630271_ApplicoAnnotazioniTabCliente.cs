namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicoAnnotazioniTabCliente : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clienti", "Nome", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clienti", "Nome", c => c.String());
        }
    }
}
