using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class FormFilmsViewModel
    {
        public IEnumerable<Genere> Generi{ get; set; }

       
        public int Id { get; set; }

        public string Titolo { get => Id == 0 ? "Nuovo FIlm" : "Modifica FIlm"; }

        [Required]
        public string Nome { get; set; }

        [Display(Name = "Numero in stock")]
        [Range(1, 20, ErrorMessage = "Il numero deve essere compreso tra 1-20")]
        [Required]
        public int NumeroInStock { get; set; }

        [Display(Name = "Data di uscita")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("genere")]
        [Required]
        public byte Idgenere { get; set; }

        public virtual ICollection<MappingImmaginiFilms> MappingImmaginiFilms { get; set; }
        public string[] FilmImages { get; set; }

        public FormFilmsViewModel()
        {
            Id = 0;
            MappingImmaginiFilms = new List<MappingImmaginiFilms>();
            FilmImages = new string[] { };
        }

        public List<SelectList> ImageLists { get; set; }
       

        public FormFilmsViewModel(Film film)
        {
            Id = film.Id;
            Nome = film.Nome;
            NumeroInStock= film.NumeroInStock;
            ReleaseDate = film.ReleaseDate;
            Idgenere = film.Idgenere ;
            MappingImmaginiFilms = film.MappingImmaginiFilms;
        }
    }
}