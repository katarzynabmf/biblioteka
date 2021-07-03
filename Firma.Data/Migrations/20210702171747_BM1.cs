using Microsoft.EntityFrameworkCore.Migrations;

namespace Firma.Data.Migrations
{
    public partial class BM1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Produkt2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tytul",
                table: "Produkt2",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Wydawnictwo",
                table: "Produkt2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ilosc",
                table: "ElementKoszyka",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Produkt2");

            migrationBuilder.DropColumn(
                name: "Tytul",
                table: "Produkt2");

            migrationBuilder.DropColumn(
                name: "Wydawnictwo",
                table: "Produkt2");

            migrationBuilder.DropColumn(
                name: "Ilosc",
                table: "ElementKoszyka");
        }
    }
}
