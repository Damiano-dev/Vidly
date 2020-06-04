namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiungoGliAbbonamentiTabClienti : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abbonamenti",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        TassaIscrizione = c.Short(nullable: false),
                        Sconto = c.Byte(nullable: false),
                        DurataInMesi = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clienti", "IscrittoAllaNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clienti", "IdAbbonamento", c => c.Byte(nullable: false));
            CreateIndex("dbo.Clienti", "IdAbbonamento");
            AddForeignKey("dbo.Clienti", "IdAbbonamento", "dbo.Abbonamenti", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clienti", "IdAbbonamento", "dbo.Abbonamenti");
            DropIndex("dbo.Clienti", new[] { "IdAbbonamento" });
            DropColumn("dbo.Clienti", "IdAbbonamento");
            DropColumn("dbo.Clienti", "IscrittoAllaNewsletter");
            DropTable("dbo.Abbonamenti");
        }
    }
}
