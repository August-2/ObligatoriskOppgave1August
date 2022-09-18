﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObligatoriskOppgave1August.Data;

#nullable disable

namespace ObligatoriskOppgave1August.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220918150028_Second config")]
    partial class Secondconfig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ObligatoriskOppgave1August.Models.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Verktøy"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Kjøretøy"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Dagligvarer"
                        });
                });

            modelBuilder.Entity("ObligatoriskOppgave1August.Models.Entities.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManufacturerId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturer", (string)null);

                    b.HasData(
                        new
                        {
                            ManufacturerId = 1,
                            Address = "Lodve Langesgate 2, 8514 Narvik",
                            Name = "UiT Norges arktiske universitet i Narvik"
                        },
                        new
                        {
                            ManufacturerId = 2,
                            Address = "Hawthorne, California, USA",
                            Name = "SpaceX"
                        });
                });

            modelBuilder.Entity("ObligatoriskOppgave1August.Models.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            ManufacturerId = 1,
                            Name = "Hammer",
                            Price = 121.50m
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            ManufacturerId = 1,
                            Name = "Vinkelsliper",
                            Price = 1520.00m
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            ManufacturerId = 1,
                            Name = "Volvo XC90",
                            Price = 990000m
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            ManufacturerId = 1,
                            Name = "Volvo XC60",
                            Price = 620000m
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 3,
                            ManufacturerId = 2,
                            Name = "Brød",
                            Price = 25.50m
                        });
                });

            modelBuilder.Entity("ObligatoriskOppgave1August.Models.Entities.Product", b =>
                {
                    b.HasOne("ObligatoriskOppgave1August.Models.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObligatoriskOppgave1August.Models.Entities.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("ObligatoriskOppgave1August.Models.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ObligatoriskOppgave1August.Models.Entities.Manufacturer", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
