using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Firma.PortalWWW.Models;
using Firma.Data.Data;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        //to jest obiekt reprezentujący całą bazę danych
        private readonly FirmaContext _context;       
        private readonly ILogger<HomeController> _logger;

        public HomeController(FirmaContext context)
        {
            _context = context; // tu inicjalizujemy bazę danych
        }

        public IActionResult Index(int? id)//tu znajduje się id strony, która klikniety lub null gdy portal ładuje się pierwszy raz
        {
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
            //jeżeli portal ładuje się pierwszy raz, to otwieramy stronę z bazy
            if (id == null)
                id = _context.Strona.First().IdStrony;
            //odnajdujemy strone o danym ID
            var item = _context.Strona.Find(id);
            //stronę o danym id przekazujemy do widoku Index (bo jestesmy w funkcji index)
            return View(item);

        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Kontakt()
        {
            return View(); //kontroler zaraca widok o takiej samej nazwie jak funkcja czyli kontakt
        }
        public IActionResult Produkty()
        {
            return View(); //kontroler zaraca widok o takiej samej nazwie jak funkcja czyli Porukty
        }
        public IActionResult About()
        {
            return View(); //kontroler zaraca widok o takiej samej nazwie jak funkcja czyli ABout
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
