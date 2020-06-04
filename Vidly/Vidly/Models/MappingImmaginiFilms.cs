using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MappingImmaginiFilms
    {
        public int ID { get; set; }
        public int ImageNumber { get; set; }
        public int FIlmID { get; set; }
        public int ImmagineFilmID { get; set; }
        public virtual Film Film { get; set; }
        public virtual ImmagineFilm ImmagineFilm { get; set; }
    }
}