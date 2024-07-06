using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPICore.Data.Models;

namespace WebAPICore.Data.Context
{
    public class WebAPICoreContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CurrentWeather> Weathers { get; set; }

        public WebAPICoreContext(DbContextOptions<WebAPICoreContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer
                { ID = 1, Name = "Nick", BirthDate = DateTime.Now, Email = "nick@email.com" });

            modelBuilder.Entity<Customer>().HasData(new Customer
                { ID = 2, Name = "Bob", BirthDate = DateTime.Now, Email = "bob@email.com" });
        }
    }
}
