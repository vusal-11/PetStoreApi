using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PetsData.DbContexts;

public class PetDbContext : DbContext
{

    public DbSet<AnimalType> AnimalTypes { get; set; }

    public DbSet<Pet> Pets { get; set; }

    public DbSet<PetCategory> PetCategories { get; set; }

    public DbSet<ProductCategory> ProductCategories { get; set; }

    public DbSet<ProductType> ProductTypes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        var config = new ConfigurationBuilder()
            .AddUserSecrets<PetDbContext>()
            .Build();



        var connectionString = config["PetsData:DefaultConnection"];


        optionsBuilder.UseSqlServer(connectionString);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        var animalTypeEntity = modelBuilder.Entity<AnimalType>();
        var petCategoriesEntity = modelBuilder.Entity<PetCategory>();
        var petsEntity = modelBuilder.Entity<Pet>();
        var productCategoriesEntity = modelBuilder.Entity<ProductCategory>();
        var productTypesEntity = modelBuilder.Entity<ProductType>();

        animalTypeEntity
            .HasKey(x => x.Id);
        animalTypeEntity
            .Property(x => x.Name)
            .IsRequired();

        //------------------------------//

        productTypesEntity
           .HasKey(x => x.Id);
        productTypesEntity
            .Property(x => x.Name)
            .IsRequired();


        //----------------------------//

        productCategoriesEntity
           .HasKey(x => x.Id);
        productCategoriesEntity
            .Property(x => x.Name)
            .IsRequired();
        

        //-------------------------------------//

        
        petCategoriesEntity
            .HasKey (x => x.Id);
        petCategoriesEntity
            .Property(x => x.Name)
            .IsRequired ();
        petCategoriesEntity
            .HasOne(x => x.AnimalType)
            .WithOne(x => x.Pet)
            .HasForeignKey<AnimalType>(x => x.PetId);


        petCategoriesEntity.HasMany(x => x.Pets)
            .WithOne(x => x.PetCategory)
            .HasForeignKey(x => x.PetCategoryId);
        

        //-----------------------------------------//


        modelBuilder.Entity<Pet>().HasKey(x => x.Id);

        modelBuilder.Entity<Pet>(x =>
        {
            x.Property(x => x.Name).IsRequired();
            x.Property(x => x.Age).IsRequired();
            x.Property(x => x.Price).IsRequired();
            x.Property(x => x.Color).IsRequired();

        });

        modelBuilder.Entity<Pet>()
            .HasMany(x => x.PetCategories)
            .WithOne(x => x.Pet)
            .HasForeignKey(x => x.PetId);   

        //----------------------------------//




    }


}
