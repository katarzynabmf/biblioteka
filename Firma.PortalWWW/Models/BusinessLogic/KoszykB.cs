using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Models.BusinessLogic
{
    public class KoszykB
    {
        //to jest połączenie z bazą danych
        private readonly FirmaContextB _context;
        private string IdSesjiKoszyka; //tu będzie przechowywany identyfikator przeglądarki, któa dodaje elementy koszyka do przeglądarki

        public KoszykB(FirmaContextB context, HttpContext httpContext)
        {
            _context = context;
            IdSesjiKoszyka = GetIdSesjiKoszyka(httpContext); //this nie musi być
        }

        //to jest funkcja która zwraca  Id sesji danej przeglądarki
        private string GetIdSesjiKoszyka(HttpContext httpContext)
        {
            //jeżeli idSesjiKoszyka jest nullerm
            if (httpContext.Session.GetString("IdSesjiKoszyka") == null)
            {
                //jeżeli identity użytkownika nie jest puste i nie posiada białych znaków
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    //wtedy staje się idSesjiKoszyka
                    httpContext.Session.SetString("IdSesjiKoszyka", httpContext.User.Identity.Name);
                }
                else
                {
                    //w przeciwnym wypadku generujemy IdSesjiKoszyka przy pomocy Guid
                    Guid tempIdSesjiKoszyka = Guid.NewGuid();
                    httpContext.Session.SetString("IdSesjiKoszyka", tempIdSesjiKoszyka.ToString());
                }
            }
            return httpContext.Session.GetString("IdSesjiKoszyka").ToString();
        }
        //to jest funkcja, która dodaje nowy towar danego użytkownika do koszyka
        public void DodajDoKoszyka(Produkt2 towar)
        {
            //najpierw sprawdzamy czy w koszyku tego użytkownika jest już ten towar
            var elementKoszykaB = _context.ElementKoszykaB.Where(e => e.IdSesjiKoszyka == IdSesjiKoszyka && e.IdProduktu2 == towar.IdProduktu2).FirstOrDefault();
            //jeżeli w koszyku daengo użytkownika nie ma tego towaru 
            if (elementKoszykaB == null)
            {
                elementKoszykaB = new ElementKoszykaB()
                {
                    IdSesjiKoszyka = this.IdSesjiKoszyka,//tu daję, że ten towar jest towarem tego użytkownika
                    IdProduktu2 = towar.IdProduktu2,
                    Produkt = _context.Produkt2.Find(towar.IdProduktu2),
                    Ilosc = 1,
                    DataUtworzenia = DateTime.Now

                };
                //dodajemy nowy element do kolekcji elementó
                _context.ElementKoszykaB.Add(elementKoszykaB);
            }
            else
            {
                //jeżeli dany towar jest w koszyku danego uzytkownika to zwiększamy jego ilość o 1
                elementKoszykaB.Ilosc++;
            }
            //zapisujemy zmiany w bazie danych
            _context.SaveChanges();
        }
        //to jest metoda która pobiera elementy koszyka danego użytkownika
        public async Task<List<ElementKoszykaB>> GetElementyKoszyka()
        {
            return await _context.ElementKoszykaB.Where(e => e.IdSesjiKoszyka == IdSesjiKoszyka).Include(e => e.Produkt).ToListAsync();
        }
      //  funkcja oblicza wartosc koszyka danego uzytkownika
        public async Task<string> GetRazem()
        {
            //to jest lista wartości wszytskicj towarów danego uzytkownika
            //var suma =
            //    (
            //        from element in _context.ElementKoszyka //dla kazdego elementu koszyka
            //        where element.IdSesjiKoszyka == this.IdSesjiKoszyka //ktory nalezy do danego uzytkownika
            //        select (decimal?)element.Ilosc * element.Towar.Cena //mnożę ilosc razy cenę
            //       ).SumAsync(); //i sumuję
            //return await suma ?? decimal.Zero; //i zwracam albo tą sumę albo 0 jeżeli nie będzie tej sumy
            return "Numer rezerwacji do biblioteki";
           }
        public async Task<string> GetRezerwacja()
        {
            //to jest lista wartości wszytskicj towarów danego uzytkownika
            //var suma =
            //    (
            //        from element in _context.ElementKoszyka //dla kazdego elementu koszyka
            //        where element.IdSesjiKoszyka == this.IdSesjiKoszyka //ktory nalezy do danego uzytkownika
            //        select (decimal?)element.Ilosc * element.Towar.Cena //mnożę ilosc razy cenę
            //       ).SumAsync(); //i sumuję
            //return await suma ?? decimal.Zero; //i zwracam albo tą sumę albo 0 jeżeli nie będzie tej sumy
            var elementyKoszyka = _context.ElementKoszyka.Where(ek => ek.IdSesjiKoszyka == IdSesjiKoszyka).ToList();
            return $"Numer rezerwacji do biblioteki {DateTime.Now.ToShortDateString()} {string.Join(" ", elementyKoszyka.Select(ek => ek.IdTowaru))}";
        }
    }
}
