using Firma.Data.Data.CMS;
using Firma.Data.Data.Sklep;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firma.Data.Data
{
    public class FirmaContextB : DbContext
    {
        public FirmaContextB(DbContextOptions<FirmaContextB> options)
            : base(options)
        {
        }

        public DbSet<Strona> Strona { get; set; }

        public DbSet<Aktualnosc> Aktualnosc { get; set; }

        public DbSet<Parametr> Parametr { get; set; }

        public DbSet<Produkt> Produkt { get; set; }

        public DbSet<Produkt2> Produkt2 { get; set; }

        public DbSet<Rodzaj> Rodzaj { get; set; }

        public DbSet<Towar> Towar { get; set; }

        public DbSet<ElementKoszyka> ElementKoszyka { get; set; }

        public DbSet<ElementKoszykaB> ElementKoszykaB { get; set; }
    }
}
