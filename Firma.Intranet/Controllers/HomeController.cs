using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Firma.Intranet.Models;
using Firma.Data.Data;

namespace Firma.Intranet.Controllers
{
    public class HomeController : Controller
    {
        //to jest obiekt reprezentujący całą bazę danych
        private readonly FirmaContext _context;
        private readonly ILogger<HomeController> _logger;

       // public HomeController(ILogger<HomeController> logger)
     //   {
          //  _logger = logger;
     //   }
    public HomeController(FirmaContext context)

        {
            _context = context;
          //  _logger = logger;
        }

        public IActionResult Index(int? id)
        {
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


          //  return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
