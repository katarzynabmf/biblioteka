using Microsoft.EntityFrameworkCore.Migrations;

namespace Firma.Data.Migrations
{
    public partial class B1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produkt2",
                columns: table => new
                {
                    IdProduktu2 = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(nullable: false),
                    Nazwa = table.Column<string>(nullable: false),
                    FotoURL = table.Column<string>(nullable: false),
                    Ilosc = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    IdRodzaju = table.Column<int>(nullable: false),
                    RodzajIdRodzaju = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt2", x => x.IdProduktu2);
                    table.ForeignKey(
                        name: "FK_Produkt2_Rodzaj_RodzajIdRodzaju",
                        column: x => x.RodzajIdRodzaju,
                        principalTable: "Rodzaj",
                        principalColumn: "IdRodzaju",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkt2_RodzajIdRodzaju",
                table: "Produkt2",
                column: "RodzajIdRodzaju");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkt2");
        }
    }
}
