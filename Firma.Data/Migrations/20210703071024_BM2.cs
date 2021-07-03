using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Firma.Data.Migrations
{
    public partial class BM2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tytul",
                table: "Aktualnosc",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAktualna",
                table: "Aktualnosc",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FotoURL",
                table: "Aktualnosc",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAktualna",
                table: "Aktualnosc");

            migrationBuilder.DropColumn(
                name: "FotoURL",
                table: "Aktualnosc");

            migrationBuilder.AlterColumn<string>(
                name: "Tytul",
                table: "Aktualnosc",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80);
        }
    }
}
