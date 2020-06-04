namespace Vidly.Migrations
{
    using Owin;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vidly.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Vidly.Models.ApplicationDbContext>
    {
        public Configuration()
        {
          
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
           // var abbonamenti = new List<TipoAbbonamento>()
           //{
           //    new TipoAbbonamento{Id = 1 ,Tipo = "A consumo",Sconto = 0, TassaIscrizione= 0, DurataInMesi = 0},
           //    new TipoAbbonamento{Id = 2 ,Tipo = "Mensile",Sconto = 10, TassaIscrizione= 30, DurataInMesi = 1},
           //    new TipoAbbonamento{Id = 3 ,Tipo = "Trimestrale",Sconto = 15, TassaIscrizione= 90, DurataInMesi = 3},
           //    new TipoAbbonamento{Id = 4 ,Tipo = "Annuale",Sconto = 20, TassaIscrizione= 300, DurataInMesi = 12}
           //};

           // foreach (var abbonamento in abbonamenti)
           // {
           //     context.abbonamenti.AddOrUpdate(a => a.Id, abbonamento);
           // }

           // var clientiF = new List<Cliente>()
           // {
           //     new Cliente {Id = 8, Nome = "Damiano", IscrittoAllaNewsletter = true, IdAbbonamento = 2},
           //     new Cliente {Id = 9, Nome = "Miriam", IscrittoAllaNewsletter = false, IdAbbonamento = 1},
           //     new Cliente {Id = 10, Nome = "Lorenzo", IscrittoAllaNewsletter = true, IdAbbonamento = 3}
           // };


           // foreach (var cliente in clientiF)
           // {
           //     context.clienti.AddOrUpdate(a => a.Nome, cliente);
           // }
        }
    }
}
