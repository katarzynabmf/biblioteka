using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Firma.Data.Data.Sklep
{
    //w tej klasie będą przechowywane wszytskie elementy koszyka wszytskich użytkowników
    public class ElementKoszykaB
    {
        [Key]
        public int IdElementuKoszyka { get; set; }
        public string IdSesjiKoszyka { get; set; } // to jest identyfikator przeglądarki
        public int IdProduktu2 { get; set; }
        public virtual Produkt2 Produkt { get; set; }
        public int Ilosc { get; set; }
        public DateTime DataUtworzenia { get; set; }
    }
}
