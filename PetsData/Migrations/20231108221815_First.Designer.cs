﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetsData.DbContexts;

#nullable disable

namespace PetsData.Migrations
{
    [DbContext(typeof(PetDbContext))]
    [Migration("20231108221815_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetsData.Models.AnimalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetId")
                        .IsUnique();

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("AnimalTypes");
                });

            modelBuilder.Entity("PetsData.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("PetsData.Models.PetCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("PetCategories");
                });

            modelBuilder.Entity("PetsData.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("PetsData.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("PetsData.Models.AnimalType", b =>
                {
                    b.HasOne("PetsData.Models.PetCategory", "Pet")
                        .WithOne("AnimalType")
                        .HasForeignKey("PetsData.Models.AnimalType", "PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetsData.Models.ProductCategory", null)
                        .WithMany("AnimalTypes")
                        .HasForeignKey("ProductCategoryId");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("PetsData.Models.PetCategory", b =>
                {
                    b.HasOne("PetsData.Models.Pet", "Pet")
                        .WithMany("PetCategories")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("PetsData.Models.ProductType", b =>
                {
                    b.HasOne("PetsData.Models.ProductCategory", null)
                        .WithMany("ProductType")
                        .HasForeignKey("ProductCategoryId");
                });

            modelBuilder.Entity("PetsData.Models.Pet", b =>
                {
                    b.Navigation("PetCategories");
                });

            modelBuilder.Entity("PetsData.Models.PetCategory", b =>
                {
                    b.Navigation("AnimalType")
                        .IsRequired();
                });

            modelBuilder.Entity("PetsData.Models.ProductCategory", b =>
                {
                    b.Navigation("AnimalTypes");

                    b.Navigation("ProductType");
                });
#pragma warning restore 612, 618
        }
    }
}
