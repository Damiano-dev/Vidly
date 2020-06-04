using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class ClientiController : Controller
    {
        ApplicationDbContext _context;

        public ClientiController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        //VideoEConsumatori videoEConsumatori = new VideoEConsumatori()
        //{
        //    clienti = new List<Cliente> { new Cliente { Id = 1, Nome = "Damiano" }, new Cliente { Id = 2, Nome = "Miriam" } }
        //};

        // GET: Clienti
        public ActionResult Index()
        {
            //_context.abbonamenti.Load();
            return View();
        }


        //public ActionResult Dettagli(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var clienteScelto = _context.clienti.Include(c=>c.TipoAbbonamento).SingleOrDefault(c => c.Id == Id);

           

        //    return View(clienteScelto);
        //}


        public ActionResult NuovoCliente()
        {
            FormClienteViewModel nuovoCliente = new FormClienteViewModel()
            {
                VMAbbonamenti = _context.abbonamenti.ToList(),
                Cliente = new Cliente() // serve per evitare che si crei un validation error sll'id che sarebbe nullo se il cliente non fosse inizializzato
            };

            return View("FormCliente",nuovoCliente);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salva(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FormClienteViewModel()
                {
                    Cliente = cliente,
                    VMAbbonamenti = _context.abbonamenti.ToList()
                };

                return View("FormCliente", viewModel);
            }

            if (cliente.Id==0)
            {
                _context.clienti.Add(cliente);
            }
            else
            {
                var clienteInDb = _context.clienti.Single(c => c.Id == cliente.Id);

                clienteInDb.Nome = cliente.Nome;
                clienteInDb.dataDiNascita = cliente.dataDiNascita;
                clienteInDb.IscrittoAllaNewsletter = cliente.IscrittoAllaNewsletter;
                clienteInDb.IdAbbonamento = cliente.IdAbbonamento;
            }

            _context.SaveChanges();


            return RedirectToAction("Index","Clienti");
        }

        [HttpGet]
        public ActionResult Modifica(int Id)
        {
            var cliente = _context.clienti.SingleOrDefault(c => c.Id == Id);

            if (cliente==null)
            {
                return HttpNotFound();
            }

            var viewModel = new FormClienteViewModel()
            {
                Cliente = cliente,
                VMAbbonamenti = _context.abbonamenti.ToList()
            };

            return View("FormCliente",viewModel);
        }
    }
}