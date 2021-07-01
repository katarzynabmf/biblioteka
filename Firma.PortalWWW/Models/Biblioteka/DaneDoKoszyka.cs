using Firma.Data.Data.Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Models.Biblioteka
{
    //to jest klasa dzięki której będzie poprawnie działał koszyk
    //żeby koszyk dobrze działał muszą być w nim elementy zamówione oraz wartość (razem) tych elementów 
    public class DaneDoKoszyka
    {
        public List<ElementKoszyka> ElementyKoszyka { get; set; }
        public decimal Razem { get; set; }
    }
}
