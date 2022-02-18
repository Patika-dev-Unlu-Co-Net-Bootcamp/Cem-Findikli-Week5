﻿// <auto-generated />
using System;
using CarDealer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarDealer.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220214021334_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarDealer.Core.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Xc90",
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 2, 14, 5, 13, 34, 19, DateTimeKind.Local).AddTicks(8202),
                            Model = "Volvo",
                            Price = 800000m
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Mercedes",
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 2, 14, 5, 13, 34, 20, DateTimeKind.Local).AddTicks(6648),
                            Model = "A180",
                            Price = 550000m
                        },
                        new
                        {
                            Id = 3,
                            Brand = "3.20i",
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 2, 14, 5, 13, 34, 20, DateTimeKind.Local).AddTicks(6665),
                            Model = "Bmw",
                            Price = 600000m
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Focus",
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 2, 14, 5, 13, 34, 20, DateTimeKind.Local).AddTicks(6668),
                            Model = "Ford",
                            Price = 600000m
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Kuga",
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 2, 14, 5, 13, 34, 20, DateTimeKind.Local).AddTicks(6670),
                            Model = "Ford",
                            Price = 660000m
                        });
                });

            modelBuilder.Entity("CarDealer.Core.CarFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Km")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("CarFeatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 1,
                            Color = "Kırmızı",
                            Km = 100000,
                            Year = 2009
                        },
                        new
                        {
                            Id = 2,
                            CarId = 2,
                            Color = "Siyah",
                            Km = 320000,
                            Year = 2016
                        });
                });

            modelBuilder.Entity("CarDealer.Core.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Sedan",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Suv",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Cabrio",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CarDealer.Core.Car", b =>
                {
                    b.HasOne("CarDealer.Core.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CarDealer.Core.CarFeature", b =>
                {
                    b.HasOne("CarDealer.Core.Car", "Car")
                        .WithOne("CarFeature")
                        .HasForeignKey("CarDealer.Core.CarFeature", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarDealer.Core.Car", b =>
                {
                    b.Navigation("CarFeature");
                });

            modelBuilder.Entity("CarDealer.Core.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}