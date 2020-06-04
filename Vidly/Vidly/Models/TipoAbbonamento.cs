using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    [Table("Abbonamenti")]
    public class TipoAbbonamento
    {
        public byte Id { get; set; }

        [Required]
        public string Tipo { get; set; }
        public short TassaIscrizione { get; set; }
        public byte Sconto { get; set; }
        public byte DurataInMesi { get; set; }

        public static readonly byte Sconosciuto = 0;
        public static readonly byte AConsumo = 1;

    }
}