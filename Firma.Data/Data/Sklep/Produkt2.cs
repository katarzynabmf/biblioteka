using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Firma.Data.Data.Sklep
{
    public class Produkt2
    {
        [Key] //to niżej jest kluczem głównym, samo się automatycznie inkrementuje
        public int IdProduktu2 { get; set; }

        [Required(ErrorMessage = "Kod jest wymagana")] //oznacza to, że poniższe polejest wymagane , a jak się go nie wpisze pojawi się ErrorMessage
        public string Kod { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")] //oznacza to, że poniższe polejest wymagane , a jak się go nie wpisze pojawi się ErrorMessage
        public string Nazwa { get; set; }

        public string Autor { get; set; }
        public string Wydawnictwo { get; set; }

      

        [Display(Name = "Ilość")]//tu określamy jak pole będzie się nazywało na widoku - np. muszą być polskie znaki
        public int Ilosc { get; set; }

       

        [Required(ErrorMessage = "Tytuł jest wymagany")] //oznacza to, że poniższe polejest wymagane , a jak się go nie wpisze pojawi się ErrorMessage
        [Display(Name = "Tytuł")]
        public string Tytul { get; set; }

        public string Opis { get; set; }

        [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        [Display(Name = "Wybierz zdjęcie")]
        public string FotoURL { get; set; }

        //to jest definicja klucza obcego
        public int IdRodzaju { get; set; }
        public virtual Rodzaj Rodzaj { get; set; }
    }
}
