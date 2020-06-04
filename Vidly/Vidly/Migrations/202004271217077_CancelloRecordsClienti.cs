namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CancelloRecordsClienti : DbMigration
    {
        public override void Up()
        {
            Sql("Delete from Clienti");
        }
        
        public override void Down()
        {
        }
    }
}
