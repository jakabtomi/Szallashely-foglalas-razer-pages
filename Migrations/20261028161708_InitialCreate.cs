using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Szallashely_foglalas_razer_pages.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Szobak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Szam = table.Column<string>(type: "TEXT", nullable: false),
                    Ferohely = table.Column<int>(type: "INTEGER", nullable: false),
                    EjszakaiAr = table.Column<decimal>(type: "TEXT", nullable: false),
                    Leiras = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szobak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foglalasok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SzobaId = table.Column<int>(type: "INTEGER", nullable: false),
                    VendegNev = table.Column<string>(type: "TEXT", nullable: false),
                    Erkezes = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Tavozas = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Letszam = table.Column<int>(type: "INTEGER", nullable: false),
                    Allapot = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foglalasok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foglalasok_Szobak_SzobaId",
                        column: x => x.SzobaId,
                        principalTable: "Szobak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foglalasok_SzobaId",
                table: "Foglalasok",
                column: "SzobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Szobak_Szam",
                table: "Szobak",
                column: "Szam",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foglalasok");

            migrationBuilder.DropTable(
                name: "Szobak");
        }
    }
}
