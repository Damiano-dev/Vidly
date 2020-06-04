using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MaggiorenniValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           var cliente = (Cliente)validationContext.ObjectInstance;

            if (cliente.IdAbbonamento==TipoAbbonamento.Sconosciuto||cliente.IdAbbonamento== TipoAbbonamento.AConsumo) 
            {
                return ValidationResult.Success;
            }

            if (cliente.dataDiNascita==null)
            {
                return new ValidationResult("La data di nascita è obbligatoria!");
            }


            var età = DateTime.Now.Year - cliente.dataDiNascita.Value.Year;

            return età >= 18 ? ValidationResult.Success : new ValidationResult("Bisogna essere maggiorenni per abbonarsi!");
        }
    }
}