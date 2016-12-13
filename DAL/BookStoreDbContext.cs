﻿using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.DAL
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}