using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Firma.Data.Data.Sklep
{
    public class Towar
    {
        [Key] //to niżej jest kluczem głównym, samo się automatycznie inkrementuje
        public int IdTowaru { get; set; }

        [Required(ErrorMessage = "Kod jest wymagana")] //oznacza to, że poniższe polejest wymagane , a jak się go nie wpisze pojawi się ErrorMessage
        public string Kod { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")] //oznacza to, że poniższe polejest wymagane , a jak się go nie wpisze pojawi się ErrorMessage
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }

        [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        [Display(Name = "Wybierz zdjęcie")]
        public string FotoURL { get; set; }


        public string Opis { get; set; }

        //to jest definicja klucza obcego
        public int IdRodzaju { get; set; }
        public virtual Rodzaj Rodzaj { get; set; }
    }
}
