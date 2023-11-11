﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetsData.DbContexts;

#nullable disable

namespace PetsData.Migrations
{
    [DbContext(typeof(PetDbContext))]
    partial class PetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("Id");

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

                    b.Property<int>("PetCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetCategoryId");

                    b.HasIndex("ProductId");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnimalTypeId");

                    b.ToTable("PetCategories");
                });

            modelBuilder.Entity("PetsData.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
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

                    b.Property<int>("PetCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCategoryTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetCategoryId");

                    b.HasIndex("ProductCategoryTypeId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("PetsData.Models.ProductCategoryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategoryTypes");
                });

            modelBuilder.Entity("PetsData.Models.ProductSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("SpecificationId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("SpecificationId");

                    b.ToTable("ProductSpecifications");
                });

            modelBuilder.Entity("PetsData.Models.Specification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("PetsData.Models.Pet", b =>
                {
                    b.HasOne("PetsData.Models.PetCategory", "PetCategory")
                        .WithMany("Pets")
                        .HasForeignKey("PetCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetsData.Models.Product", "Product")
                        .WithMany("Pets")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetCategory");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PetsData.Models.PetCategory", b =>
                {
                    b.HasOne("PetsData.Models.AnimalType", "AnimalType")
                        .WithMany("PetCategories")
                        .HasForeignKey("AnimalTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnimalType");
                });

            modelBuilder.Entity("PetsData.Models.Product", b =>
                {
                    b.HasOne("PetsData.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("PetsData.Models.ProductCategory", b =>
                {
                    b.HasOne("PetsData.Models.PetCategory", "PetCategory")
                        .WithMany("ProductCategories")
                        .HasForeignKey("PetCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetsData.Models.ProductCategoryType", "ProductCategoryType")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductCategoryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetCategory");

                    b.Navigation("ProductCategoryType");
                });

            modelBuilder.Entity("PetsData.Models.ProductSpecification", b =>
                {
                    b.HasOne("PetsData.Models.ProductCategory", "ProductCategory")
                        .WithMany("ProductSpecifications")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetsData.Models.Specification", "Specification")
                        .WithMany("ProductSpecifications")
                        .HasForeignKey("SpecificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");

                    b.Navigation("Specification");
                });

            modelBuilder.Entity("PetsData.Models.AnimalType", b =>
                {
                    b.Navigation("PetCategories");
                });

            modelBuilder.Entity("PetsData.Models.PetCategory", b =>
                {
                    b.Navigation("Pets");

                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("PetsData.Models.Product", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("PetsData.Models.ProductCategory", b =>
                {
                    b.Navigation("ProductSpecifications");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("PetsData.Models.ProductCategoryType", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("PetsData.Models.Specification", b =>
                {
                    b.Navigation("ProductSpecifications");
                });
#pragma warning restore 612, 618
        }
    }
}
