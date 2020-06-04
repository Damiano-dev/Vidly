using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome del cliente è obbligatorio")]
        [StringLength(255)]
        public string Nome { get; set; }

        public bool IscrittoAllaNewsletter { get; set; }

        public TipoAbbonamentoDTO tipoAbbonamento { get; set; }

        //[MaggiorenniValidation]
        public DateTime? dataDiNascita { get; set; }

        public byte IdAbbonamento { get; set; }
    }
}