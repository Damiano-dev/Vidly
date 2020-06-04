namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProvaSeed : DbMigration
    {
        public override void Up()
        {
            Sql("delete from clienti");

        }
        
        public override void Down()
        {
        }
    }
}
