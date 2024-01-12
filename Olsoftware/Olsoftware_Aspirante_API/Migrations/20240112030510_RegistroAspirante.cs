using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlsoftwareAspiranteAPI.Migrations
{
    /// <inheritdoc />
    public partial class RegistroAspirante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Aspirantes",
                columns: new[] { "Id", "Apellidos", "Calificacion", "Celular", "Clave", "Direccion", "Email", "EstadoPrueba", "FechaActualizacion", "Identificacion", "Nombres", "Usuario" },
                values: new object[] { 1, "Paz Mena", 74m, "1223345", "123uju", "Calle Luna", "ana@gmail.com", "Proceso", new DateTime(2024, 1, 11, 22, 5, 10, 777, DateTimeKind.Local).AddTicks(8478), "789654", "Ana Maria", "ana@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aspirantes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
