using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Firma.Data.Data.CMS
{
    public class Strona
    {
        [Key] //to niżej jest kluczem głównym, samo się automatycznie inkrementuje
        public int IdStrony { get; set; }

        [Required(ErrorMessage = "Tytuł linku jest wymagany")] //oznacza to, że poniższe polejest wymagane , a jak się go nie wpisze pojawi się ErrorMessage
        [MaxLength(10, ErrorMessage = "Tytuł powinien mieć max 10 znaków")]//określenie maksymalnej liczby znaków
        [Display(Name = "Tytuł odnośnika")]//tu określamy jak pole będzie się nazywało na widoku
        public string LinkTytul { get; set; }

        [Required(ErrorMessage = "Tytuł strony jest wymagany")] //oznacza to, że poniższe polejest wymagane , a jak się go nie wpisze pojawi się ErrorMessage
        [MaxLength(50, ErrorMessage = "Tytuł powinien mieć max 50 znaków")]//określenie maksymalnej liczby znaków
        [Display(Name = "Tytuł")]//tu określamy jak pole będzie się nazywało na widoku
        public string Tytul { get; set; }

        [Column(TypeName = "nvarchar(MAX)")] // tu wymaszamy jakiego typu pole będzie w bazie danych
        [Display(Name = "Treść")]//tu określamy jak pole będzie się nazywało na widoku - np. muszą być polskie znaki
        public string Tresc { get; set; }

        [Display(Name = "Pozycja wyświetlania")]
        [Required(ErrorMessage = "Wpisz pozycję wyświetlania")] //oznacza to, że poniższe polejest wymagane , a jak się go nie wpisze pojawi się ErrorMessage
        public int Pozycja { get; set; }
    }
}
