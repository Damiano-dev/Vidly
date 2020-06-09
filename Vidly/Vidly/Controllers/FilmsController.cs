using AutoMapper;
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
    public class FilmsController : Controller
    {
        //VideoEConsumatori videoEConsumatori = new VideoEConsumatori()
        //{
        //    VMfilms = new List<Film> { new Film { Id = 1, Nome = "Avengers" }, new Film { Id = 2, Nome = "Avatar" } }
        //};

        ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Films
        public ActionResult Index()
        {
            
            var listaFilms = _context.films.Include(g => g.genere).ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index", listaFilms);
            
                
                return View("ReadOnlyIndex", listaFilms);

           // return View(_context.films.Include(g => g.genere).ToList());
        }

        //[Route("Films/Data/{anno:regex(\\d{4})}/{mese:regex(\\d{2})}")]  //Attenzione allo slash corretto
        //public ActionResult Data(int Anno, int Mese)
        //{
        //    return Content("Anno = "+ Anno + "/" + Mese);
        //}

        //public ActionResult Dettagli(int? id)
        //{
        //    if (id ==null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var filmScelto = _context.films.Include(g=>g.genere).SingleOrDefault(f => f.Id == id);

        //    return View(filmScelto);
        //}

        //[Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult NuovoFilm()
        {
            FormFilmsViewModel viewModel = new FormFilmsViewModel()
            {
                Generi = _context.generi.ToList(),
                ImageLists = new List<SelectList>()

            };

            for (int i = 0; i < Costanti.NumberOfProductImages; i++)
            {
                viewModel.ImageLists.Add(new SelectList(_context.immagineFilms, "ID", "NomeFile"));
            }

            return View("FilmForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(FormFilmsViewModel filmViewModel)
        {

            if (!ModelState.IsValid)
            {
                //var viewModel = new FormFilmsViewModel(film)
                //{
                //    Generi = _context.generi.ToList()
                //};

                filmViewModel.Generi = _context.generi.ToList();
                return View("FIlmForm", filmViewModel);                  //viewModel);
            }

            Film film = Mapper.Map<FormFilmsViewModel, Film>(filmViewModel);

            film.Disponibilità = (byte)filmViewModel.NumeroInStock;
            film.DataInserimentoInDatabase = DateTime.Now;
            film.MappingImmaginiFilms = new List<MappingImmaginiFilms>();

                                                                       
            string[] listaImages = filmViewModel.FilmImages.Where(pi => !string.IsNullOrEmpty(pi)).ToArray();

            for (int i = 0; i < listaImages.Length; i++)
            {
                filmViewModel.MappingImmaginiFilms.Add(new MappingImmaginiFilms
                {
                    ImmagineFilm = _context.immagineFilms.Find(int.Parse(listaImages[i])),
                    ImageNumber = i,
                    
                });
            }

            filmViewModel.ImageLists = new List<SelectList>();
            film.MappingImmaginiFilms = filmViewModel.MappingImmaginiFilms;

            

            if (film.Id == 0)
            {
                for (int i = 0; i < Costanti.NumberOfProductImages; i++)
                {
                    filmViewModel.ImageLists.Add(new SelectList(_context.immagineFilms, "ID", "NomeFile",
                    filmViewModel.FilmImages[i]));
                }

                _context.films.Add(film);
            }
            else
            {
                var filmInDB = _context.films.Single(f => f.Id == film.Id);

                filmInDB.Nome = film.Nome;
                filmInDB.ReleaseDate = film.ReleaseDate;
                filmInDB.Idgenere = film.Idgenere;
                filmInDB.NumeroInStock = film.NumeroInStock;

            }

            //if (film.Id==0)
            //{
            //    film.DataInserimentoInDatabase = DateTime.Now;
            //    film.Disponibilità = (byte)film.NumeroInStock;
            //    _context.films.Add(film);
            //}
            //else
            //{
            //    var filmInDB = _context.films.Single(f => f.Id == film.Id);

            //    filmInDB.Nome = film.Nome;
            //    filmInDB.ReleaseDate = film.ReleaseDate;
            //    filmInDB.Idgenere = film.Idgenere;
            //    filmInDB.NumeroInStock = film.NumeroInStock;

            //}

            _context.SaveChanges();

            return RedirectToAction("Index", "Films");
        }

        [HttpGet]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Modifica(int Id)
        {
            var film = _context.films.SingleOrDefault(f => f.Id == Id);

            if (film==null)
            {
                return HttpNotFound();
            }

            var viewModel = new FormFilmsViewModel(film)
            {
                Generi = _context.generi.ToList()
            };

            return View("FilmForm", viewModel);
        }

    }
}