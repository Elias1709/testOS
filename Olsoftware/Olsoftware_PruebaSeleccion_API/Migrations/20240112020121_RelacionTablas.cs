using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlsoftwarePruebaSeleccionAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AspiranteId",
                table: "PruebaSeleccions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Aspirantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoPrueba = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calificacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aspirante", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PruebaSeleccions_AspiranteId",
                table: "PruebaSeleccions",
                column: "AspiranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PruebaSeleccions_Aspirante_AspiranteId",
                table: "PruebaSeleccions",
                column: "AspiranteId",
                principalTable: "Aspirantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PruebaSeleccions_Aspirante_AspiranteId",
                table: "PruebaSeleccions");

            migrationBuilder.DropTable(
                name: "Aspirantes");

            migrationBuilder.DropIndex(
                name: "IX_PruebaSeleccions_AspiranteId",
                table: "PruebaSeleccions");

            migrationBuilder.DropColumn(
                name: "AspiranteId",
                table: "PruebaSeleccions");
        }
    }
}
