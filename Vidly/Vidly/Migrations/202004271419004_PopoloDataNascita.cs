namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopoloDataNascita : DbMigration
    {
        public override void Up()
        {
            Sql("Update Clienti set Data_di_nascita =  CAST('1984-10-09' AS DATETIME) where Id = 14");
            Sql("Update Clienti set Data_di_nascita = CAST('1991-05-26' AS DATETIME)  where Id = 15");
        }
        
        public override void Down()
        {
        }
    }
}
