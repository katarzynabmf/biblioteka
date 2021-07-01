using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Firma.Data.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Towar",
                columns: table => new
                {
                    IdTowaru = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Towar", x => x.IdTowaru);
                    table.ForeignKey(
                        name: "FK_Towar_Rodzaj_RodzajIdRodzaju",
                        column: x => x.RodzajIdRodzaju,
                        principalTable: "Rodzaj",
                        principalColumn: "IdRodzaju",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementKoszyka",
                columns: table => new
                {
                    IdElementuKoszyka = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSesjiKoszyka = table.Column<string>(nullable: true),
                    IdTowaru = table.Column<int>(nullable: false),
                    TowarIdTowaru = table.Column<int>(nullable: true),
                    DataUtworzenia = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementKoszyka", x => x.IdElementuKoszyka);
                    table.ForeignKey(
                        name: "FK_ElementKoszyka_Towar_TowarIdTowaru",
                        column: x => x.TowarIdTowaru,
                        principalTable: "Towar",
                        principalColumn: "IdTowaru",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementKoszyka_TowarIdTowaru",
                table: "ElementKoszyka",
                column: "TowarIdTowaru");

            migrationBuilder.CreateIndex(
                name: "IX_Towar_RodzajIdRodzaju",
                table: "Towar",
                column: "RodzajIdRodzaju");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementKoszyka");

            migrationBuilder.DropTable(
                name: "Towar");
        }
    }
}
