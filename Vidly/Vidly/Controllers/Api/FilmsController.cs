using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class FilmsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Films
        public IEnumerable<FilmDTO> Getfilms(string query=null)
       {
            var filmQuery = db.films.Include(g => g.genere);
            if (!string.IsNullOrWhiteSpace(query))
            {
                filmQuery = filmQuery.Where(q => q.Nome.Contains(query));//&& q.Disponibilità>0);
            }

            var films = filmQuery.ToList().Select(Mapper.Map<Film, FilmDTO>);
            return films;
        }

        // GET: api/Films/5
        [ResponseType(typeof(FilmDTO))]
        public IHttpActionResult GetFilm(int id)
        {
            Film film = db.films.Find(id);
            if (film == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Film, FilmDTO>(film));
        }

        // PUT: api/Films/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult PutFilm(int id, FilmDTO film)
        {
            var filmInDb = db.films.SingleOrDefault(f => f.Id == id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (filmInDb==null)
            {
                return NotFound();
            }

            

            Mapper.Map(film, filmInDb);


            //filmInDb.Nome = film.Nome;
            //filmInDb.NumeroInStock = film.NumeroInStock;
            //filmInDb.ReleaseDate = film.ReleaseDate;
            //filmInDb.Idgenere = film.Idgenere;

            db.SaveChanges();
            db.Entry(filmInDb).State = EntityState.Modified;

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Films
        [ResponseType(typeof(FilmDTO))]
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult PostFilm(FilmDTO filmDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var film = Mapper.Map<FilmDTO, Film>(filmDto);
            film.DataInserimentoInDatabase = DateTime.Now;

            db.films.Add(film);
            db.SaveChanges();

            filmDto.Id = film.Id;
            return CreatedAtRoute("DefaultApi", new { id = film.Id }, filmDto);
        }

        // DELETE: api/Films/5
        [ResponseType(typeof(FilmDTO))]
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        [Route("api/films/{id:int}")]
        public IHttpActionResult DeleteFilm(int id)
        {
            Film film = db.films.Find(id);

            if (film == null)
            {
                return NotFound();
            }

            db.films.Remove(film);
            db.SaveChanges();

            return Ok(Mapper.Map<Film, FilmDTO>(film));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilmExists(int id)
        {
            return db.films.Count(e => e.Id == id) > 0;
        }
    }
}