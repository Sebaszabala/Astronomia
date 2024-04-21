﻿// <auto-generated />
using System;
using AstronomiaEjercicio.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AstronomiaEjercicio.Migrations
{
    [DbContext(typeof(CaracteristicasDbContext))]
    partial class CaracteristicasDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AstronomiaEjercicio.Model.Caracteristicas", b =>
                {
                    b.Property<int>("Id_Caracteristicas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Caracteristicas"));

                    b.Property<string>("Caracteristica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_TiposObjetos")
                        .HasColumnType("int");

                    b.Property<int?>("Tipos_ObjetosId_TiposObjetos")
                        .HasColumnType("int");

                    b.HasKey("Id_Caracteristicas");

                    b.HasIndex("Tipos_ObjetosId_TiposObjetos");

                    b.ToTable("Caracteristicas");
                });

            modelBuilder.Entity("AstronomiaEjercicio.Model.Institutos", b =>
                {
                    b.Property<int>("Id_Instituto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Instituto"));

                    b.Property<string>("NombreInstituto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Instituto");

                    b.ToTable("Instituto");
                });

            modelBuilder.Entity("AstronomiaEjercicio.Model.Observaciones", b =>
                {
                    b.Property<int>("Id_Observacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Observacion"));

                    b.Property<string>("Coordenadas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Observador")
                        .HasColumnType("int");

                    b.Property<int>("Id_Telescopio")
                        .HasColumnType("int");

                    b.Property<int>("Id_TipoObjeto")
                        .HasColumnType("int");

                    b.Property<string>("Magnitud")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ObservadoresId_Observador")
                        .HasColumnType("int");

                    b.Property<int?>("TelescopioId_telescopio")
                        .HasColumnType("int");

                    b.Property<int?>("Tipos_ObjetosId_TiposObjetos")
                        .HasColumnType("int");

                    b.HasKey("Id_Observacion");

                    b.HasIndex("ObservadoresId_Observador");

                    b.HasIndex("TelescopioId_telescopio");

                    b.HasIndex("Tipos_ObjetosId_TiposObjetos");

                    b.ToTable("Observacion");
                });

            modelBuilder.Entity("AstronomiaEjercicio.Model.Observadores", b =>
                {
                    b.Property<int>("Id_Observador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Observador"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_Instituto")
                        .HasColumnType("int");

                    b.Property<string>("Instituto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InstitutosId_Instituto")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Observador");

                    b.HasIndex("InstitutosId_Instituto");

                    b.ToTable("Observador");
                });

            modelBuilder.Entity("AstronomiaEjercicio.Model.Telescopio", b =>
                {
                    b.Property<int>("Id_telescopio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_telescopio"));

                    b.Property<string>("Diametro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreTelescopio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_telescopio");

                    b.ToTable("Telescopios");
                });

            modelBuilder.Entity("AstronomiaEjercicio.Model.Tipos_Objetos", b =>
                {
                    b.Property<int>("Id_TiposObjetos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_TiposObjetos"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_TiposObjetos");

                    b.ToTable("Tipo_Objeto");
                });

            modelBuilder.Entity("AstronomiaEjercicio.Model.Caracteristicas", b =>
                {
                    b.HasOne("AstronomiaEjercicio.Model.Tipos_Objetos", "Tipos_Objetos")
                        .WithMany()
                        .HasForeignKey("Tipos_ObjetosId_TiposObjetos");

                    b.Navigation("Tipos_Objetos");
                });

            modelBuilder.Entity("AstronomiaEjercicio.Model.Observaciones", b =>
                {
                    b.HasOne("AstronomiaEjercicio.Model.Observadores", "Observadores")
                        .WithMany()
                        .HasForeignKey("ObservadoresId_Observador");

                    b.HasOne("AstronomiaEjercicio.Model.Telescopio", "Telescopio")
                        .WithMany()
                        .HasForeignKey("TelescopioId_telescopio");

                    b.HasOne("AstronomiaEjercicio.Model.Tipos_Objetos", "Tipos_Objetos")
                        .WithMany()
                        .HasForeignKey("Tipos_ObjetosId_TiposObjetos");

                    b.Navigation("Observadores");

                    b.Navigation("Telescopio");

                    b.Navigation("Tipos_Objetos");
                });

            modelBuilder.Entity("AstronomiaEjercicio.Model.Observadores", b =>
                {
                    b.HasOne("AstronomiaEjercicio.Model.Institutos", "Institutos")
                        .WithMany()
                        .HasForeignKey("InstitutosId_Instituto");

                    b.Navigation("Institutos");
                });
#pragma warning restore 612, 618
        }
    }
}
