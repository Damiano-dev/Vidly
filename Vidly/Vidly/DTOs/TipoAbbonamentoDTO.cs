using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class TipoAbbonamentoDTO
    {
        public byte Id { get; set; }

        [Required]
        public string Tipo { get; set; }
    }
}