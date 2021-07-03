using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data.Sklep;
using Firma.Data.Data;

namespace Firma.Intranet.Controllers
{
    public class Produkt2Controller : Controller
    {
        private readonly FirmaContextB _context;

        public Produkt2Controller(FirmaContextB context)
        {
            _context = context;
        }

        // GET: Produkt2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produkt2.ToListAsync());
        }

        // GET: Produkt2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt2 = await _context.Produkt2
                .FirstOrDefaultAsync(m => m.IdProduktu2 == id);
            if (produkt2 == null)
            {
                return NotFound();
            }

            return View(produkt2);
        }

        // GET: Produkt2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produkt2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produkt2 produkt2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produkt2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produkt2);
        }

        // GET: Produkt2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt2 = await _context.Produkt2.FindAsync(id);
            if (produkt2 == null)
            {
                return NotFound();
            }
            return View(produkt2);
        }

        // POST: Produkt2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduktu2,Kod,Nazwa,Autor,Wydawnictwo,Ilosc,Tytul,Opis,FotoURL,IdRodzaju")] Produkt2 produkt2)
        {
            if (id != produkt2.IdProduktu2)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkt2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Produkt2Exists(produkt2.IdProduktu2))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produkt2);
        }

        // GET: Produkt2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt2 = await _context.Produkt2
                .FirstOrDefaultAsync(m => m.IdProduktu2 == id);
            if (produkt2 == null)
            {
                return NotFound();
            }

            return View(produkt2);
        }

        // POST: Produkt2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produkt2 = await _context.Produkt2.FindAsync(id);
            _context.Produkt2.Remove(produkt2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Produkt2Exists(int id)
        {
            return _context.Produkt2.Any(e => e.IdProduktu2 == id);
        }
    }
}
