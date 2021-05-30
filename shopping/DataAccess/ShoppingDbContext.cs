
using shopping.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace shopping.DataAccess
{
    public class ShoppingDbContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-KTGKU66;Initial Catalog=Shopping;Integrated Security=True");

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapping code 
            modelBuilder.
                Entity<Category>()
                .ToTable("tblCategory");

            modelBuilder.
              Entity<Brand>()
              .ToTable("tblBrand");

            modelBuilder.Entity<Product>()
                .ToTable("tblProduct");

        }


        public DbSet<Category> Categories { get; set; }

       
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Product> Products { get; set; }

    }


}
