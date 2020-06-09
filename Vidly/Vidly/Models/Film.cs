using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public byte Disponibilità { get; set; }

        [Display(Name = "Numero in stock")]
        [Range(1,20,ErrorMessage = "Il numero deve essere compreso tra 1-20")]
        [Required]
        public int NumeroInStock { get; set; }

        [Required]
        public DateTime DataInserimentoInDatabase { get; set; }

        [Display(Name = "Data di uscita")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Genere")]
        public Genere genere { get; set; }

       
        [ForeignKey("genere")]
        [Required]
        public byte Idgenere{ get; set; }

        public virtual ICollection<MappingImmaginiFilms> MappingImmaginiFilms { get; set; }
    }
}