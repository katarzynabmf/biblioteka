using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly FirmaContext _context; // tak tworzymy połączenie z bazą danych
        public SklepController(FirmaContext context)
        {
            _context = context; // tu inicjalizujemy baze danych
        }


        public async Task<IActionResult> Index(int? id) // w id będzie przechowywny id rodzaju którego towary mmy wyświetlić
        {
            //do ViewBag zapisuję wszystkie rodzaje z bazy danych asynchronicznie (musimy użyć using Microsoft.EntityFrameworkCore;)
            ViewBag.Rodzaje = await _context.Rodzaj.ToListAsync();


            ViewBag.ModelStrony =
              (
              from strona in _context.Strona // dla każdej strony z bazy danych stron
              orderby strona.Pozycja // posortowanej względem pozycji
              select strona // wybieramy stronę
              ).ToList();
            ViewBag.ModelAktualnosci =
                (
                from aktualnosc in _context.Aktualnosc // dla każdej strony z bazy danych stron
                orderby aktualnosc.Pozycja // posortowanej względem pozycji
                select aktualnosc // wybieramy stronę
                ).ToList();
            ViewBag.ModelParametry =
                (
                from parametr in _context.Parametr // dla każdej strony z bazy danych stron
                orderby parametr.IdParametru // posortowanej względem pozycji
                select parametr // wybieramy stronę
                ).ToList();
            ViewBag.ModelTowary =
                (
                from towar in _context.Towar // dla każdej strony z bazy danych stron
                orderby towar.IdTowaru // posortowanej względem pozycji
                select towar // wybieramy stronę
                ).ToList();


            //przy pierwszym uruchomieniu sklepu nie ma wybranego rodzaju więc pod rodzaj podstawimy pierwszy rodzaj z bazy danych
            if (id == null)
            {
                var pierwszy = await _context.Rodzaj.FirstAsync();
                id = pierwszy.IdRodzaju;
            }
            //do widoku przekazuję wszytskie towary danego rodzaju ktróego mamy id asynchronicznie
            return View(await _context.Towar.Where(item => item.IdRodzaju == id).ToListAsync());
        }

        //funkcja zwraca do widoku towar o id danym jako parametr

        public async Task<IActionResult> Szczegoly(int id)
        {
            ViewBag.Rodzaje = await _context.Rodzaj.ToListAsync();
            return View(await _context.Towar.Where(t => t.IdTowaru == id).FirstOrDefaultAsync());
        }
    }
}