using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class VideoEConsumatori
    {
        public List<Film> VMfilms { get; set; }
        public List<Cliente> clienti { get; set; }
    }
}