using System.IO;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EasyManager.Infra.Data.Context
{
    public class EasyManagerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }  // -this- //
        public DbSet<Manufacture> Manufactures { get; set; }  // -this- //
        public DbSet<Product> Products { get; set; }  // -this- //
        public DbSet<SalesTable> SalesTables { get; set; }  // -this- //
        public DbSet<Category> Categories { get; set; }  // -this- //
        public DbSet<Bank> Banks { get; set; }  
        public DbSet<BankAccount> BankAccounts { get; set; }  // -this- //
        public DbSet<CredcardOperator> CredcardOperators { get; set; }  
        public DbSet<Departament> Departaments { get; set; }  // -this- //
        public DbSet<Financial> Financias { get; set; }  // -this- //
        public DbSet<Order> Orders { get; set; }  
        public DbSet<PaymentMethod> PaymentMethods { get; set; }  // -this- //
        public DbSet<Purchase> Purchases { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new SalesTableMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new BankMap());
            modelBuilder.ApplyConfiguration(new BankAccountsMap());
            modelBuilder.ApplyConfiguration(new CredcardOperatorMap());
            modelBuilder.ApplyConfiguration(new DepartamentMap());
            modelBuilder.ApplyConfiguration(new FinancialMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new PaymentMethodMap());
            modelBuilder.ApplyConfiguration(new PurchaseMap());
                        
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