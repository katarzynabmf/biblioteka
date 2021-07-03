using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Firma.Data.Migrations
{
    public partial class BM4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElementKoszykaB",
                columns: table => new
                {
                    IdElementuKoszyka = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSesjiKoszyka = table.Column<string>(nullable: true),
                    IdProduktu2 = table.Column<int>(nullable: false),
                    ProduktIdProduktu2 = table.Column<int>(nullable: true),
                    Ilosc = table.Column<int>(nullable: false),
                    DataUtworzenia = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementKoszykaB", x => x.IdElementuKoszyka);
                    table.ForeignKey(
                        name: "FK_ElementKoszykaB_Produkt2_ProduktIdProduktu2",
                        column: x => x.ProduktIdProduktu2,
                        principalTable: "Produkt2",
                        principalColumn: "IdProduktu2",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementKoszykaB_ProduktIdProduktu2",
                table: "ElementKoszykaB",
                column: "ProduktIdProduktu2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementKoszykaB");
        }
    }
}
