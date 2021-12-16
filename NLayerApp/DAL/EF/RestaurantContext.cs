using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.EF
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Portion> Portions { get; set; }

        private string connectionString;

        public RestaurantContext(string connection)
        {
            connectionString = connection;
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().HasData( //.HasMany<>().WithMany()
            new Dish[]
            {
                new Dish { ID=1, Name="Soup" },//, Ingredients=new Collection<Ingredient>() },
                new Dish { ID=2, Name="Porridge"},
                new Dish { ID=3, Name="Pizza"},
            });
        }

    }
}
