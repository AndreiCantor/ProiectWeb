using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectWeb.Migrations
{
    public partial class claseparticipari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Abonament",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Clasa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembruId = table.Column<int>(type: "int", nullable: true),
                    ClasaId = table.Column<int>(type: "int", nullable: true),
                    DataOra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participare_Clasa_ClasaId",
                        column: x => x.ClasaId,
                        principalTable: "Clasa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participare_Membru_MembruId",
                        column: x => x.MembruId,
                        principalTable: "Membru",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participare_ClasaId",
                table: "Participare",
                column: "ClasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Participare_MembruId",
                table: "Participare",
                column: "MembruId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participare");

            migrationBuilder.DropTable(
                name: "Clasa");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Abonament",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
