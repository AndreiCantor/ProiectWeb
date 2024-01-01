using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectWeb.Migrations
{
    public partial class Inscriere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscriere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembruId = table.Column<int>(type: "int", nullable: true),
                    AbonamentId = table.Column<int>(type: "int", nullable: true),
                    DataInscriere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInchiere = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscriere_Abonament_AbonamentId",
                        column: x => x.AbonamentId,
                        principalTable: "Abonament",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inscriere_Membru_MembruId",
                        column: x => x.MembruId,
                        principalTable: "Membru",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscriere_AbonamentId",
                table: "Inscriere",
                column: "AbonamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriere_MembruId",
                table: "Inscriere",
                column: "MembruId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriere");
        }
    }
}
