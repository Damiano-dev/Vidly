using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Range(1, 20, ErrorMessage = "Il numero deve essere compreso tra 1-20")]
        [Required]
        public int NumeroInStock { get; set; }

        [Required]
        public byte Disponibilità { get; set; }

        public GenereDTO genere { get; set; }

        [Required]
        public DateTime DataInserimentoInDatabase { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }


      
        [Required]
        public byte Idgenere { get; set; }
    }
}