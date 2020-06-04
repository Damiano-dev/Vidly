namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiornoTabFilms : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Generi (Id,Nome) values (1,'Fantascienza')");
            Sql("Insert into Generi (Id,Nome) values (2,'Azione')");
            Sql("Insert into Generi (Id,Nome) values (3,'Avventura')");
            Sql("Insert into Generi (Id,Nome) values (4,'Horror')");
            Sql("Insert into Generi (Id,Nome) values (5,'Comico')");
            Sql("Insert into Generi (Id,Nome) values (6,'Fantastico')");
            Sql("Insert into Generi (Id,Nome) values (7,'Drammatico')");
            Sql("Insert into Generi (Id,Nome) values (8,'Erotico')");
            Sql("Insert into Films (Nome, NumeroInStock, DataInserimentoInDatabase, ReleaseDate, Idgenere) values ('Avengers',5, Cast('2020/04/27' as datetime), Cast('2012/04/25' as datetime),1 )");
            Sql("Insert into Films (Nome, NumeroInStock, DataInserimentoInDatabase, ReleaseDate, Idgenere) values ('Avatar',3, Cast('2020/04/27' as datetime), Cast('2010/01/15' as datetime),6)");
            Sql("Insert into Films (Nome, NumeroInStock, DataInserimentoInDatabase, ReleaseDate, Idgenere) values ('Quasi amici',1, Cast('2020/04/27' as datetime), Cast('2012/02/24' as datetime),7 )");
            Sql("Insert into Films (Nome, NumeroInStock, DataInserimentoInDatabase, ReleaseDate, Idgenere) values ('Esorcista',2, Cast('2020/04/27' as datetime), Cast('1974/10/04' as datetime),4 )");
            Sql("Insert into Films (Nome, NumeroInStock, DataInserimentoInDatabase, ReleaseDate, Idgenere) values ('Cado dalle nubi',7, Cast('2020/04/27' as datetime), Cast('2009/11/27' as datetime),5 )");
        }
        
        public override void Down()
        {
        }
    }
}
