using System.IO;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EasyManager.Infra.Data.Context
{
    public class EasyManagerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Manufacture> Manufactures { get; set; }  
        public DbSet<Product> Products { get; set; }  
        public DbSet<SalesTable> SalesTables { get; set; }  
        public DbSet<Category> Categories { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new SalesTableMap());
                        
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            var connectionString = config.GetConnectionString("DefaultConnection");

            // define the database to use
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}