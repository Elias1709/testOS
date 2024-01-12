﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Olsoftware_Aspirante_API.Datos;

#nullable disable

namespace OlsoftwareAspiranteAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240112030510_RegistroAspirante")]
    partial class RegistroAspirante
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Olsoftware_Aspirante_API.Modelos.Aspirante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Calificacion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoPrueba")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aspirantes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Paz Mena",
                            Calificacion = 74m,
                            Celular = "1223345",
                            Clave = "123uju",
                            Direccion = "Calle Luna",
                            Email = "ana@gmail.com",
                            EstadoPrueba = "Proceso",
                            FechaActualizacion = new DateTime(2024, 1, 11, 22, 5, 10, 777, DateTimeKind.Local).AddTicks(8478),
                            Identificacion = "789654",
                            Nombres = "Ana Maria",
                            Usuario = "ana@gmail.com"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
