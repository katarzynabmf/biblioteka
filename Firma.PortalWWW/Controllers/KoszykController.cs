using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Firma.PortalWWW.Models.Biblioteka;
using Firma.PortalWWW.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Firma.PortalWWW.Controllers
{
    public class KoszykController : Controller
    {
        private readonly FirmaContextB _context; // tak tworzymy połączenie z bazą danych
        public KoszykController(FirmaContextB context)
        {
            _context = context; // tu inicjalizujemy baze danych
        }
        //to jest funkcja która dostarcza dane do widokuprezentującego cały koszyk
        public async Task<IActionResult> Index()
        {
            KoszykB koszyk = new KoszykB(_context, this.HttpContext);
            //ten obiekt tworzony jest tylko po to żeby w jednym obiekcie do widoku przekazać dwa elementy: elementy koszyka, razem
            //do widoku można przekazać tylko 1 element!!!!!!! dlatego tworzymy klase ktora bedzie miala 2 elementy w sobie zeby moc je przakazac
            DaneDoKoszyka daneDoKoszyka = new DaneDoKoszyka
            {
                ElementyKoszykaB = await koszyk.GetElementyKoszyka(),
                // Razem = await koszyk.GetRazem()
                Rezerwacja = await koszyk.GetRezerwacja()
            };
            //przekazujemy dane do koszyka złozone z dwoch elementów do widoku
            return View(daneDoKoszyka);
        }
        //funkcja kontrolera dodaje towar do koszyka
        //to jest akcja, ktora zostanie wywołana pod przyciskiem dodaj do koszyka
        public async Task<ActionResult> DodajDoKoszyka(int id)
        {
            KoszykB koszyk = new KoszykB(_context, this.HttpContext);
            koszyk.DodajDoKoszyka(await _context.Produkt2.FindAsync(id));
            //po dodaniu towaru do koszyka przechodze do tego koszyka, czyli do Index, który wyswietli koszyk
            return RedirectToAction("Index");//to jest przejscie do widoku indeks
        }
    }
}