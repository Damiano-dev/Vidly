using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using System.Data.Entity;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class RentalController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult NewRental(RentalDTO RentalDto)
        {

            var clienteApi = context.clienti.Single(c => c.Id == RentalDto.ClienteId);
            List<Film> films = new List<Film>();

            foreach (var idfilm in RentalDto.FilmsIds)
            {
                films.Add(context.films.Single(f => f.Id == idfilm));
            }

            //var films = context.films.Where(f => RentalDto.FilmsIds.Contains(f.Id)).ToList();

            foreach (var filmApi in films)
            {

                filmApi.Disponibilità--;

                var rental = new Rental
                {
                    cliente = clienteApi,
                    film = filmApi,
                    DataAffitto = DateTime.Now
                };

                
                context.rental.Add(rental);
            }

            context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IEnumerable<FilmDTO> RestituisciFilms(string domanda)
        {
            context.clienti.Load();
            var rentals = context.rental.Include(f=>f.film).Where(c => c.cliente.Nome.Contains(domanda));
            //var statoCliente = new RentalDTO() { FilmsIds = new List<int>() };
            List<FilmDTO> listaFilms = new List<FilmDTO>();

            foreach (var rent in rentals)
            {
                var nuovoFilm = Mapper.Map<Film, FilmDTO>(rent.film);
                listaFilms.Add(nuovoFilm);
            }


            return listaFilms;
        }

        [HttpDelete]
        [Route("api/rental/{id:int}")]
        public void FilmsRestituiti(int id)
        {

            var rentsDaEliminare = context.rental.Include(f=>f.film).Where(f => f.film.Id == id);

            Rental rent = rentsDaEliminare.First();

            rent.film.Disponibilità++;

            context.rental.Remove(rent);

            context.SaveChanges();
        }
    }
}
