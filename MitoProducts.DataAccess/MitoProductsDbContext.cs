using Microsoft.EntityFrameworkCore;
using MitoProductos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MitoProducts.DataAccess
{
    public class MitoProductsDbContext : DbContext
    {
        public MitoProductsDbContext(DbContextOptions<MitoProductsDbContext> options) : base(options)
        {

        }
        public MitoProductsDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(x => x.UnitPrice)
                .HasPrecision(11, 2);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"Server=localhost;Database=MitoProductsDb;Uid=sa;Pwd=Hecatombe@2019$;App=Api");
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
