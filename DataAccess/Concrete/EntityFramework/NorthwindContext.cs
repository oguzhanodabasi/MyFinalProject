using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;Database = Northwind; Trusted_Connection = true");
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Order>? Orders { get; set; }

        //Fluent Mapping -> İstediğimiz entityi isim farketmeksizin istediğimiz tabloya alttaki metot ile bağlayabiliriz.
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Customer>().ToTable("Customers","dbo");
            //modelBuilder.Entity<Customer>().Property(e => e.CustomerId).HasColumnName("EmployeeID");
            //modelBuilder.Entity<Customer>().Property(e => e.ContactName).HasColumnName("ContactName");
            //modelBuilder.Entity<Customer>().Property(e => e.CompanyName).HasColumnName("CompanyName");
            //modelBuilder.Entity<Customer>().Property(e => e.City).HasColumnName("City");
        }
    }
}
