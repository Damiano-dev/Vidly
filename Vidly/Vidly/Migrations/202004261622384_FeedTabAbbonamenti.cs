namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedTabAbbonamenti : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clienti", "IdAbbonamento", "dbo.Abbonamenti");
            DropPrimaryKey("dbo.Abbonamenti");
            AlterColumn("dbo.Abbonamenti", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Abbonamenti", "Id");
            AddForeignKey("dbo.Clienti", "IdAbbonamento", "dbo.Abbonamenti", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clienti", "IdAbbonamento", "dbo.Abbonamenti");
            DropPrimaryKey("dbo.Abbonamenti");
            AlterColumn("dbo.Abbonamenti", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Abbonamenti", "Id");
            AddForeignKey("dbo.Clienti", "IdAbbonamento", "dbo.Abbonamenti", "Id", cascadeDelete: true);
        }
    }
}
