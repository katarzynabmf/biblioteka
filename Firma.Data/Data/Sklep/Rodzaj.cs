using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Firma.Data.Data.Sklep
{
    public class Rodzaj
    {
        [Key] //to niżej jest kluczem głównym, samo się automatycznie inkrementuje
        public int IdRodzaju { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")] //oznacza to, że poniższe polejest wymagane , a jak się go nie wpisze pojawi się ErrorMessage
        [MaxLength(10, ErrorMessage = "Tytuł powinien mieć max 10 znaków")]
        public string Nazwa { get; set; }

        public string Opis { get; set; }

        //danego rodzaju jest wiele towarów
        public virtual ICollection<Produkt> Produkt { get; set; }
    }
}
