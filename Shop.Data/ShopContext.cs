﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext()
        { }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
        }
    }
}
