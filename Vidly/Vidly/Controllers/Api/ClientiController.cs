using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class ClientiController : ApiController  //Attenzione quando si usa postman con put e delete, non aggiurno l'indirizzo con l'id da modificare o cancellare farlo manualmente
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // api/Clienti
        public IEnumerable<ClienteDTO> GetClienti(string query=null)
        {
            var clientiQuery = _context.clienti
                   .Include(m => m.TipoAbbonamento);

            if (!string.IsNullOrWhiteSpace(query))
            {
                clientiQuery = clientiQuery.Where(q => q.Nome.Contains(query));
            }

            var clienti = clientiQuery.ToList().Select(Mapper.Map<Cliente, ClienteDTO>);

            return clienti;
        }

        // api/Clienti/1
        public IHttpActionResult GetCliente(int id)
        {
            var clienteSelezionato = _context.clienti.SingleOrDefault(c => c.Id == id);

            if (clienteSelezionato==null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map < Cliente, ClienteDTO >(clienteSelezionato));
        }

        //Post api/Clienti
        [HttpPost]
        public IHttpActionResult NuovoCliente(ClienteDTO clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cliente = Mapper.Map<ClienteDTO, Cliente>(clienteDto);

            _context.clienti.Add(cliente);

            _context.SaveChanges();

            clienteDto.Id = cliente.Id;

            return Created(new Uri(Request.RequestUri+"/"+cliente.Id), clienteDto);
        }

        //Put api/Clienti/1
        [HttpPut]
        public void ModificaCliente(int id, ClienteDTO clienteDto)
        {
            var clienteInDb = _context.clienti.SingleOrDefault(c => c.Id == id);

            if (clienteInDb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }


            Mapper.Map(clienteDto, clienteInDb);

            //clienteInDb.Nome = cliente.Nome;
            //clienteInDb.dataDiNascita = cliente.dataDiNascita;
            //clienteInDb.IscrittoAllaNewsletter = cliente.IscrittoAllaNewsletter;
            //clienteInDb.IdAbbonamento = cliente.IdAbbonamento;

            _context.SaveChanges();
        }

        //Delete api/Clienti/1
        [HttpDelete]
        [Route("api/clienti/{id:int}")]
        public void CancellaCliente(int id)
        {
            var clienteInDb = _context.clienti.SingleOrDefault(c => c.Id == id);

            if (clienteInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.clienti.Remove(clienteInDb);
            _context.SaveChanges();
        }
    }
}
