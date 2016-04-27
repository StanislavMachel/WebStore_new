using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebStore.Domain.Entities;

namespace WebStore.DataLayer
{
    public class WebStoreDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>()
        //                .HasMany<Image>(p => p.Images)
        //                .WithRequired(i => i.Product)
        //                .HasForeignKey(i => i.ProductRefID);
        //}
    }
}
