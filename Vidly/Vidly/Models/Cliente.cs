using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    [Table("Clienti")]
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Il nome del cliente è obbligatorio")]
        [StringLength(255)]
        public string Nome { get; set; }
        public bool IscrittoAllaNewsletter { get; set; }

        [Display(Name ="Tipo di abbonamento")]
        public TipoAbbonamento TipoAbbonamento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Column("Data_di_nascita",Order = 3)]
        [Display(Name ="Data di nascita")]
        [MaggiorenniValidation]
        public DateTime? dataDiNascita { get; set; }

        [ForeignKey("TipoAbbonamento")]
        public byte IdAbbonamento { get; set; }

    }
}