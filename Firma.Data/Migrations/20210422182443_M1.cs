
using Microsoft.EntityFrameworkCore.Migrations;

namespace Firma.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktualnosc",
                columns: table => new
                {
                    IdAktualnosci = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(maxLength: 50, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Pozycja = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktualnosc", x => x.IdAktualnosci);
                });

            migrationBuilder.CreateTable(
                name: "Parametr",
                columns: table => new
                {
                    IdParametru = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: false),
                    Wartosc = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametr", x => x.IdParametru);
                });

            migrationBuilder.CreateTable(
                name: "Rodzaj",
                columns: table => new
                {
                    IdRodzaju = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 10, nullable: false),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodzaj", x => x.IdRodzaju);
                });

            migrationBuilder.CreateTable(
                name: "Strona",
                columns: table => new
                {
                    IdStrony = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(maxLength: 50, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Pozycja = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strona", x => x.IdStrony);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    IdProduktu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(nullable: false),
                    Nazwa = table.Column<string>(nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    FotoURL = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    IdRodzaju = table.Column<int>(nullable: false),
                    RodzajIdRodzaju = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.IdProduktu);
                    table.ForeignKey(
                        name: "FK_Produkt_Rodzaj_RodzajIdRodzaju",
                        column: x => x.RodzajIdRodzaju,
                        principalTable: "Rodzaj",
                        principalColumn: "IdRodzaju",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_RodzajIdRodzaju",
                table: "Produkt",
                column: "RodzajIdRodzaju");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktualnosc");

            migrationBuilder.DropTable(
                name: "Parametr");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Strona");

            migrationBuilder.DropTable(
                name: "Rodzaj");
        }
    }
}
