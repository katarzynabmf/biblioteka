using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Firma.Data.Data.CMS
{
    public class Parametr
    {
        [Key] //to niżej jest kluczem głównym, samo się automatycznie inkrementuje
        public int IdParametru { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")] //oznacza to, że poniższe polejest wymagane , a jak się go nie wpisze pojawi się ErrorMessage
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Wartość jest wymagana")] //oznacza to, że poniższe polejest wymagane , a jak się go nie wpisze pojawi się ErrorMessage
        [Display(Name = "Wartość")]//tu określamy jak pole będzie się nazywało na widoku
        public string Wartosc { get; set; }

        public string Opis { get; set; }
    }
}
