﻿// <auto-generated />
using System;
using BibliotecaV4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BibliotecaV4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190722043858_m3")]
    partial class m3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BibliotecaV4.Models.Autor", b =>
                {
                    b.Property<int>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("Nombre");

                    b.HasKey("IdAutor");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("BibliotecaV4.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Descripcion");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("BibliotecaV4.Models.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaId");

                    b.Property<int>("ISBN");

                    b.Property<int>("IdAutor");

                    b.Property<int>("IdCategoria");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("IdAutor");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("BibliotecaV4.Models.Libro", b =>
                {
                    b.HasOne("BibliotecaV4.Models.Categoria")
                        .WithMany("Libros")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("BibliotecaV4.Models.Autor")
                        .WithMany("Libros")
                        .HasForeignKey("IdAutor")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
