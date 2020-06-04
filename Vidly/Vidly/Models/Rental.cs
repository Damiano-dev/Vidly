using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int id { get; set; }

        [Required]
        public Cliente cliente { get; set; }

        [Required]
        public Film film { get; set; }


        public DateTime DataAffitto { get; set; }
        public DateTime? DataRestituzione { get; set; }
    }
}