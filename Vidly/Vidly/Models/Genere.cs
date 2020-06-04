using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    [Table("Generi")]
    public class Genere
    {
        public byte Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Film> films { get; set; }
    }
}