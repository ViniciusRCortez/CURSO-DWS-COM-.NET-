using Microsoft.EntityFrameworkCore;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Helpers;

namespace Dws.Note_one.Api.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Costumer> Costumers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Tabela Categories
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            //Tabela Products
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
            builder.Entity<Product>().Property(p => p.CategoryId).IsRequired();

            //Tabela Users
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Login).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(10);
            
            //Tabela Costumers
            builder.Entity<Costumer>().ToTable("Costumers");
            builder.Entity<Costumer>().HasKey(p => p.Id);
            builder.Entity<Costumer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Costumer>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Costumer>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Costumer>().Property(p => p.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Entity<Costumer>().Property(p => p.Credit).IsRequired();

            //Popular Categories
            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Fruits and Vegetables" },
                new Category { Id = 101, Name = "Dairy" }
            );

            //Popular Products
            builder.Entity<Product>().HasData
            (
                new Product {Id = 1, Name = "Milk", QuantityInPackage = 10, UnitOfMeasurement = EUnitOfMeasurement.Liter , CategoryId = 101},
                new Product {Id = 2, Name = "Apple", QuantityInPackage = 1, UnitOfMeasurement = EUnitOfMeasurement.Kilogram, CategoryId = 100},
                new Product {Id = 3, Name = "Onion", QuantityInPackage = 20, UnitOfMeasurement = EUnitOfMeasurement.Kilogram, CategoryId = 100}
            );

            //Popular Users
            builder.Entity<User>().HasData
            (
                new User {Id = 100, Login = "vini", Password = "12345"}                
            );

            //Popular Costumers
            builder.Entity<Costumer>().HasData
            (
                new Costumer {Id = 1, Name = "Vinicius Cortêz", Email = "viniciusfake@gmail.com", PhoneNumber = "+55 (85) 11111-1111", Credit = -10.50},
                new Costumer {Id = 2, Name = "Bruce Wayne", Email = "iamnotbatman@gmail.com", PhoneNumber = "+55 (85) 22222-2222", Credit = 1984},
                new Costumer {Id = 3, Name = "Antony Stark", Email = "iamironman@gmail.com", PhoneNumber = "+55 (85) 33333-3333", Credit = 451},
                new Costumer {Id = 4, Name = "Peter Parker", Email = "iamnotmiranha@gmail.com", PhoneNumber = "+21 (44) 44444-4444", Credit = -200.89}                
            );
        }
    }
}
