﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    [Table("ImmaginiFilms")]
    public class ImmagineFilm
    {
        public int ID { get; set; }

        [Display(Name = "File")]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string NomeFile{ get; set; }

        public virtual ICollection<MappingImmaginiFilms> MappingImmaginiFilms { get; set; }
    }
}