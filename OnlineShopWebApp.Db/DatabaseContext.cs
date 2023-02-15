using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().HasOne(p => p.Product).WithMany(p => p.Images).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);

            var product1Id = Guid.Parse("46f8de36-a3ea-40fd-ac04-22c12de5ecec");
            var product2Id = Guid.Parse("93c88b3c-855c-494d-a6ce-112dcfe988e9");
            var product3Id = Guid.Parse("252fe419-e270-48a8-b97c-11452ef2b0a8");
            var product4Id = Guid.Parse("63616282-7b7a-49e1-a991-796d2ecf22fc");

            var image1 = new Image
            {
                Id = Guid.Parse("7b6ddde3-c20a-467e-9299-e3fc34d91c66"),
                Url = "/images/Products/1.jpg",
                ProductId = product1Id,
            };
            var image2 = new Image
            {
                Id = Guid.Parse("3f9ad6e0-7137-431f-a13e-f152d279b6a2"),
                Url = "/images/Products/2.jpg",
                ProductId = product2Id,
            };
            var image3 = new Image
            {
                Id = Guid.Parse("d21c8719-bc2b-433a-abb1-5155bce9ff7f"),
                Url = "/images/Products/image3.jpg",
                ProductId = product3Id,
            };
            var image4 = new Image
            {
                Id = Guid.Parse("a36a3f9c-7751-4747-ace9-7137a68af724"),
                Url = "/images/Products/image4.jpg",
                ProductId = product4Id,
            };


            modelBuilder.Entity<Image>().HasData(image1, image2);

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(product1Id, "Beat #1", 7500, "TEMP 140 TONE Em"),
                new Product(product2Id, "Beat #2", 7700, "TEMP 144 TONE Dm"),
            });
        }
    }
}
