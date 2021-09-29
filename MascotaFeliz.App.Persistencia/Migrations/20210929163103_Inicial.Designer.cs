﻿// <auto-generated />
using System;
using MascotaFeliz.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MascotaFeliz.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20210929163103_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NombreMascota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PropietarioId")
                        .HasColumnType("int");

                    b.Property<string>("Raza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoAnimal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropietarioId");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Visita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EstadoDeAnimo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("FrecuenciaCardiaca")
                        .HasColumnType("int");

                    b.Property<int>("FrecuenciaRespiratoria")
                        .HasColumnType("int");

                    b.Property<int?>("MascotaId")
                        .HasColumnType("int");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<string>("Recomendaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Temperatura")
                        .HasColumnType("real");

                    b.Property<int?>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("Visitas");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Propietario", b =>
                {
                    b.HasBaseType("MascotaFeliz.App.Dominio.Persona");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Propietario");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Veterinario", b =>
                {
                    b.HasBaseType("MascotaFeliz.App.Dominio.Persona");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Veterinario");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Mascota", b =>
                {
                    b.HasOne("MascotaFeliz.App.Dominio.Propietario", "Propietario")
                        .WithMany()
                        .HasForeignKey("PropietarioId");

                    b.Navigation("Propietario");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Visita", b =>
                {
                    b.HasOne("MascotaFeliz.App.Dominio.Mascota", "Mascota")
                        .WithMany()
                        .HasForeignKey("MascotaId");

                    b.HasOne("MascotaFeliz.App.Dominio.Veterinario", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioId");

                    b.Navigation("Mascota");

                    b.Navigation("Veterinario");
                });
#pragma warning restore 612, 618
        }
    }
}