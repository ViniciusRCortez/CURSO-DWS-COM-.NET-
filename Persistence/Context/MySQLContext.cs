using Microsoft.EntityFrameworkCore;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Helpers;

namespace Dws.Note_one.Api.Persistence.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

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

            
        }
    }
}
