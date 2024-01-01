﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectWeb.Data;

#nullable disable

namespace ProiectWeb.Migrations
{
    [DbContext(typeof(ProiectWebContext))]
    [Migration("20240101144006_Inscriere")]
    partial class Inscriere
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProiectWeb.Models.Abonament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abonament");
                });

            modelBuilder.Entity("ProiectWeb.Models.Inscriere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AbonamentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInchiere")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInscriere")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MembruId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AbonamentId");

                    b.HasIndex("MembruId");

                    b.ToTable("Inscriere");
                });

            modelBuilder.Entity("ProiectWeb.Models.Membru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataNasterii")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumarTelefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Membru");
                });

            modelBuilder.Entity("ProiectWeb.Models.Inscriere", b =>
                {
                    b.HasOne("ProiectWeb.Models.Abonament", "Abonament")
                        .WithMany("Inscrieri")
                        .HasForeignKey("AbonamentId");

                    b.HasOne("ProiectWeb.Models.Membru", "Membru")
                        .WithMany("Inscrieri")
                        .HasForeignKey("MembruId");

                    b.Navigation("Abonament");

                    b.Navigation("Membru");
                });

            modelBuilder.Entity("ProiectWeb.Models.Abonament", b =>
                {
                    b.Navigation("Inscrieri");
                });

            modelBuilder.Entity("ProiectWeb.Models.Membru", b =>
                {
                    b.Navigation("Inscrieri");
                });
#pragma warning restore 612, 618
        }
    }
}