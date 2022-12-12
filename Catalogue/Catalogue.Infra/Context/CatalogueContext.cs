using Catalogue.Core;
using Catalogue.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infra
{
    public class CatalogueContext : DbContext
    {
        public CatalogueContext(DbContextOptions option) : base(option)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>().HasKey(x => x.Id);
            modelBuilder.Entity<Cart>().HasKey(x => x.Id);
            modelBuilder.Entity<Inventory>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().HasKey(x => x.Id);



            modelBuilder.Entity<Inventory>()
                 .HasMany(x => x.Book);


            modelBuilder.Entity<Cart>()
                .HasMany(x => x.Book);

            modelBuilder.Entity<Order>().HasMany(x => x.Book);

            modelBuilder.Entity<Book>().HasData(new List<Book>()
            {
                new Book()
                {
                    Id=1,
                    BookTitle="Five Point Some One",
                    BookAuthor="Chetan Bhagat",
                    BookPrice=12.12M
                }

            });


            modelBuilder.Entity<Inventory>().HasData(new Inventory()
            {
                Id=1,
                BookId = 1,
                Quantity = 12
            }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
