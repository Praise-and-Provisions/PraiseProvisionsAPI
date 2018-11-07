using Microsoft.EntityFrameworkCore;
using PraiseProvisionsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraiseProvisionsAPI.Data
{
    public class PraiseDBContext : DbContext
    {
        
        public PraiseDBContext(DbContextOptions<PraiseDBContext> options) : base(options)
        {
        }

        public PraiseDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Favorites>().HasKey(
                ce => new { ce.ChefID, ce.RestaurantID }
            );

            mb.Entity<Chef>().HasData(
                new Chef
                {
                    ID = 1,
                    FirstName = "Paula",
                    LastName = "Deen",
                    City = "Albany"
                },
                new Chef
                {
                    ID = 2,
                    FirstName = "Gordon",
                    LastName = "Ramsey",
                    City = "Los Angeles"
                },
                new Chef
                {
                    ID = 3,
                    FirstName = "Jimmy",
                    LastName = "Fallon",
                    City = "Jamaica"
                },
                new Chef
                {
                    ID = 4,
                    FirstName = "Jack",
                    LastName = "TheRipper",
                    City = "Omaha"
                }
            );

            mb.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    ID = 1,
                    Name = "The Pink Door",
                    Address = "1411 156th Ave NE, Ste A, Bellevue, WA 98007",
                    Description = "Chinese, Hot Pot",
                    City = "Seattle"
                },
                new Restaurant
                {
                    ID = 2,
                    Name = "Tasty n Alder",
                    Address = "14330 Lake City Way NE, Seattle, WA 98125",
                    Description = "Southern, Soul Food, Fast Food",
                    City = "Portland"
                },
                new Restaurant
                {
                    ID = 3,
                    Name = "Fog Harbor Fish House",
                    Address = "700 Bellevue Way NE, Ste 280, Bellevue, WA 98004",
                    Description = "Taiwanese, Dim Sum, Shanghainese",
                    City = "San Francisco"
                },
                new Restaurant
                {
                    ID = 4,
                    Name = "Bestia",
                    Address = "2115 Westlake Ave, Seattle, WA 98121",
                    Description = "Fast Food, American (Traditional), Burgers",
                    City = "Los Angeles"
                },
                new Restaurant
                {
                    ID = 5,
                    Name = "Levain Bakery",
                    Address = "12405 SE 38th St, Bellevue, WA 98006",
                    Description = "New York",
                    City = ""
                }
            );

            mb.Entity<Favorites>().HasData(
                new Favorites
                {
                    ChefID = 3,
                    RestaurantID = 1
                },
                new Favorites
                {
                    ChefID = 1,
                    RestaurantID = 4
                }
            );
        }

        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Favorites> Favorites { get; set; }

    }
}
