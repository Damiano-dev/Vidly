using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class RentalDTO
    {
        public int ClienteId { get; set; }
        public List<int> FilmsIds { get; set; }
    }
}