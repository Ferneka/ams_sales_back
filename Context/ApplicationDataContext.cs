using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS_Sales.Domain;
using Microsoft.EntityFrameworkCore;


namespace AMS_Sales.Context
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options):base(options){

        }
        
        public DbSet<Category> Category {get; set;}
        public DbSet<Product> Product {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Product).HasForeignKey(p => p.IdCategory).IsRequired();
        }
    }
}