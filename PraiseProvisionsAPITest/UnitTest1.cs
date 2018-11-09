using System;
using Xunit;
using PraiseProvisionsAPI.Controllers;
using PraiseProvisionsAPI.Data;
using PraiseProvisionsAPI.Models;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PraiseProvisionsAPITest
{
    public class UnitTest1
    {
        /// <summary>
        /// Test that we can get a chefs properties
        /// </summary>
        [Fact]
        public void CanGetChef()
        {
            Chef chef = new Chef();
            chef.FirstName = "David";
            chef.LastName = "Wells";
            Assert.Equal("David", chef.FirstName);
            Assert.Equal("Wells", chef.LastName);
        }


        /// <summary>
        /// Test that we can set a chefs properties
        /// </summary>
        [Fact]
        public void CanSetChef()
        {
            Chef chef = new Chef();
            chef.FirstName = "Jimmy";
            chef.LastName = "G";

            chef.FirstName = "California";
            Assert.Equal("California", chef.FirstName);
        }


        /// <summary>
        /// Test that a chef can be added to the database
        /// </summary>
        [Fact]
        public async void CanAddChefToDatabase()
        {
            DbContextOptions<PraiseDBContext> options =
                new DbContextOptionsBuilder<PraiseDBContext>()
                .UseInMemoryDatabase("DBPraise")
                .Options;

            using (PraiseDBContext context = new PraiseDBContext(options))
            {
                Chef chef = new Chef();
                chef.FirstName = "Paula";
                chef.LastName = "Deen";

                context.Chefs.Add(chef);
                context.SaveChanges();

                var Chef = await context.Chefs.FirstOrDefaultAsync(x => x.FirstName == chef.FirstName);
                var Last = await context.Chefs.FirstOrDefaultAsync(x => x.LastName == chef.LastName);
                Assert.Equal("Paula", Chef.FirstName);
                Assert.Equal("Deen", Chef.LastName);
            }
        }


        /// <summary>
        /// Test that a chef can be updated after being added to the database
        /// </summary>
        [Fact]
        public async void CanUpdateChefToDatabase()
        {
            DbContextOptions<PraiseDBContext> options =
                new DbContextOptionsBuilder<PraiseDBContext>()
                .UseInMemoryDatabase("DBPraise")
                .Options;

            using (PraiseDBContext context = new PraiseDBContext(options))
            {
                Chef chef = new Chef();
                chef.FirstName = "Paula";
                chef.LastName = "Deen";

                context.Chefs.Add(chef);
                context.SaveChanges();

                chef.FirstName = "Dame";
                chef.LastName = "Mike";
                context.Chefs.Update(chef);

                var ChefFistName = await context.Chefs.FirstOrDefaultAsync(x => x.FirstName == chef.FirstName);
                var ChefLastName = await context.Chefs.FirstOrDefaultAsync(x => x.LastName == chef.LastName);

                Assert.Equal("Dame", ChefFistName.FirstName);
                Assert.Equal("Mike", ChefLastName.LastName);
            }
        }


        /// <summary>
        /// Can create a restaurant
        /// </summary>
        [Fact]
        public void CanGetRestaurant()
        {
            Restaurant rest = new Restaurant();
            rest.Address = "2901 3rd Ave #300, Seattle, WA 98121";
            rest.Description = "Hot Fire!";
            rest.Name = "Arby's";
            rest.ID = 1;

            Assert.Equal("2901 3rd Ave #300, Seattle, WA 98121", rest.Address);
            Assert.Equal("Hot Fire!", rest.Description);
            Assert.Equal("Arby's", rest.Name);
            Assert.Equal(1, rest.ID);
        }


        /// <summary>
        /// Test that a restaurant properties can be set
        /// </summary>
        [Fact]
        public void CanSetRestaurant()
        {
            Restaurant rest = new Restaurant();
            rest.Address = "2901 3rd Ave #300, Seattle, WA 98121";
            rest.Description = "Hot Fire!";
            rest.Name = "Arby's";
            rest.ID = 1;

            rest.Name = "Bakers";
            Assert.Equal("Bakers", rest.Name);
        }


        /// <summary>
        /// Can add a rest to the database
        /// </summary>
        [Fact]
        public async void CanAddRestToDatabase()
        {
            DbContextOptions<PraiseDBContext> options =
                new DbContextOptionsBuilder<PraiseDBContext>()
                .UseInMemoryDatabase("DBPraise")
                .Options;

            using (PraiseDBContext context = new PraiseDBContext(options))
            {
                Restaurant rest = new Restaurant();
                rest.Address = "2901 3rd Ave #300, Seattle, WA 98121";
                rest.Description = "Hot Fire!";
                rest.Name = "Arby's";
                rest.ID = 1;

                context.Restaurants.Add(rest);
                context.SaveChanges();

                var RestAddress = await context.Restaurants.FirstOrDefaultAsync(x => x.Address == rest.Address);
                var RestDescription = await context.Restaurants.FirstOrDefaultAsync(x => x.Description == rest.Description);
                var RestName = await context.Restaurants.FirstOrDefaultAsync(x => x.Name == rest.Name);
                var RestID = await context.Restaurants.FirstOrDefaultAsync(x => x.ID == rest.ID);

                Assert.Equal("2901 3rd Ave #300, Seattle, WA 98121", RestAddress.Address);
                Assert.Equal("Hot Fire!", RestDescription.Description);
                Assert.Equal("Arby's", RestName.Name);
                Assert.Equal(1, RestID.ID);
            }
        }


        /// <summary>
        /// Test that rest can be updated in the database
        /// </summary>
        [Fact]
        public async void CanUpdateRestToDatabase()
        {
            DbContextOptions<PraiseDBContext> options =
                new DbContextOptionsBuilder<PraiseDBContext>()
                .UseInMemoryDatabase("DBPraise")
                .Options;

            using (PraiseDBContext context = new PraiseDBContext(options))
            {
                Restaurant rest = new Restaurant();
                rest.Address = "2901 3rd Ave #300, Seattle, WA 98121";
                rest.Description = "Hot Fire!";
                rest.Name = "Arby's";
                rest.ID = 3;

                context.Restaurants.Add(rest);
                context.SaveChanges();

                rest.Address = "2624 NE University Village St, Seattle, WA 98105";
                rest.Description = "Super Hot Fire!";
                rest.Name = "Pretzels Plus";
                rest.ID = 2;
                context.Restaurants.Add(rest);
                context.SaveChanges();

                var RestAddress = await context.Restaurants.FirstOrDefaultAsync(x => x.Address == rest.Address);
                var RestDescription = await context.Restaurants.FirstOrDefaultAsync(x => x.Description == rest.Description);
                var RestName = await context.Restaurants.FirstOrDefaultAsync(x => x.Name == rest.Name);
                var RestID = await context.Restaurants.FirstOrDefaultAsync(x => x.ID == rest.ID);

                Assert.Equal("2624 NE University Village St, Seattle, WA 98105", RestAddress.Address);
                Assert.Equal("Super Hot Fire!", RestDescription.Description);
                Assert.Equal("Pretzels Plus", RestName.Name);
                Assert.Equal(2, RestID.ID);
            }
        }

        /// <summary>
        /// Can get favorites
        /// </summary>
        [Fact]
        public void CanGetFavorites()
        {
            Chef chef = new Chef();
            chef.FirstName = "TK";
            chef.LastName = "Mite";

            Restaurant rest = new Restaurant();
            rest.Address = "2901 3rd Ave #300, Seattle, WA 98121";
            rest.Description = "Hot Fire!";
            rest.Name = "Arby's";
            rest.ID = 3;

            Favorites favs = new Favorites();
            favs.Chef = chef;
            favs.Restaurant = rest;

            Assert.Equal("TK", favs.Chef.FirstName);
            Assert.Equal("Mite", favs.Chef.LastName);
            Assert.Equal("2901 3rd Ave #300, Seattle, WA 98121", favs.Restaurant.Address);
            Assert.Equal("Hot Fire!", favs.Restaurant.Description);
            Assert.Equal("Arby's", favs.Restaurant.Name);
            Assert.Equal(3, favs.Restaurant.ID);
        }


        /// <summary>
        /// Test that a favorites properties can be set
        /// </summary>
        [Fact]
        public void CanSetFavorites()
        {
            Chef chef = new Chef();
            chef.FirstName = "TK";
            chef.LastName = "Mite";

            Restaurant rest = new Restaurant();
            rest.Address = "2901 3rd Ave #300, Seattle, WA 98121";
            rest.Description = "Hot Fire!";
            rest.Name = "Arby's";
            rest.ID = 3;

            chef.FirstName = "Table";
            chef.LastName = "Top";

            rest.Address = "Back Alley";
            rest.Description = "Super Hot Fire!";
            rest.Name = "BK";
            rest.ID = 55;

            Favorites favs = new Favorites();
            favs.Chef = chef;
            favs.Restaurant = rest;

            Assert.Equal("Table", favs.Chef.FirstName);
            Assert.Equal("Top", favs.Chef.LastName);
            Assert.Equal("Back Alley", favs.Restaurant.Address);
            Assert.Equal("Super Hot Fire!", favs.Restaurant.Description);
            Assert.Equal("BK", favs.Restaurant.Name);
            Assert.Equal(55, favs.Restaurant.ID);
        }


        /// <summary>
        /// Can add a favorites to the database
        /// </summary>
        [Fact]
        public async void CanAddFavoritesToDatabase()
        {
            DbContextOptions<PraiseDBContext> options =
                new DbContextOptionsBuilder<PraiseDBContext>()
                .UseInMemoryDatabase("DBPraise")
                .Options;

            using (PraiseDBContext context = new PraiseDBContext(options))
            {
                Chef chef = new Chef();
                chef.FirstName = "TK";
                chef.LastName = "Mite";

                Restaurant rest = new Restaurant();
                rest.Address = "2901 3rd Ave #300, Seattle, WA 98121";
                rest.Description = "Hot Fire!";
                rest.Name = "Arby's";
                rest.ID = 39;

                Favorites favs = new Favorites();
                favs.Chef = chef;
                favs.Restaurant = rest;

                context.Favorites.Add(favs);
                context.SaveChanges();

                var RestAddress = await context.Favorites.FirstOrDefaultAsync(x => x.Restaurant.Address == favs.Restaurant.Address);
                var RestDescription = await context.Favorites.FirstOrDefaultAsync(x => x.Restaurant.Description == favs.Restaurant.Description);
                var RestName = await context.Favorites.FirstOrDefaultAsync(x => x.Restaurant.Name == favs.Restaurant.Name);
                var RestID = await context.Favorites.FirstOrDefaultAsync(x => x.Restaurant.ID == favs.Restaurant.ID);

                var ChefFirstName = await context.Favorites.FirstOrDefaultAsync(x => x.Chef.FirstName == favs.Chef.FirstName);
                var ChefLastName = await context.Favorites.FirstOrDefaultAsync(x => x.Chef.LastName == favs.Chef.LastName);

                Assert.Equal("2901 3rd Ave #300, Seattle, WA 98121", RestAddress.Restaurant.Address);
                Assert.Equal("Hot Fire!", RestDescription.Restaurant.Description);
                Assert.Equal("Arby's", RestName.Restaurant.Name);
                Assert.Equal(39, RestID.Restaurant.ID);

                Assert.Equal("TK", ChefFirstName.Chef.FirstName);
                Assert.Equal("Mite", ChefLastName.Chef.LastName);
            }
        }


        /// <summary>
        /// Test that favorites can be updated in the database
        /// </summary>
        [Fact]
        public async void CanUpdateFavoritesToDatabase()
        {
            DbContextOptions<PraiseDBContext> options =
               new DbContextOptionsBuilder<PraiseDBContext>()
               .UseInMemoryDatabase("DBPraise")
               .Options;

            using (PraiseDBContext context = new PraiseDBContext(options))
            {
                Chef chef = new Chef();
                chef.FirstName = "TK";
                chef.LastName = "Mite";

                Restaurant rest = new Restaurant();
                rest.Address = "2901 3rd Ave #300, Seattle, WA 98121";
                rest.Description = "Hot Fire!";
                rest.Name = "Arby's";
                rest.ID = 444;

                Favorites favs = new Favorites();
                favs.Chef = chef;
                favs.Restaurant = rest;

                context.Favorites.Add(favs);
                context.SaveChanges();

                chef.FirstName = "Tip";
                chef.LastName = "Harris";

                rest.Address = "Side Alley";
                rest.Description = "Hot!";
                rest.Name = "Pizza Hut";

                favs.Chef = chef;
                favs.Restaurant = rest;

                context.Favorites.Update(favs);
                context.SaveChanges();

                var RestAddress = await context.Favorites.FirstOrDefaultAsync(x => x.Restaurant.Address == favs.Restaurant.Address);
                var RestDescription = await context.Favorites.FirstOrDefaultAsync(x => x.Restaurant.Description == favs.Restaurant.Description);
                var RestName = await context.Favorites.FirstOrDefaultAsync(x => x.Restaurant.Name == favs.Restaurant.Name);
                var RestID = await context.Favorites.FirstOrDefaultAsync(x => x.Restaurant.ID == favs.Restaurant.ID);

                var ChefFirstName = await context.Favorites.FirstOrDefaultAsync(x => x.Chef.FirstName == favs.Chef.FirstName);
                var ChefLastName = await context.Favorites.FirstOrDefaultAsync(x => x.Chef.LastName == favs.Chef.LastName);

                Assert.Equal("Side Alley", RestAddress.Restaurant.Address);
                Assert.Equal("Hot!", RestDescription.Restaurant.Description);
                Assert.Equal("Pizza Hut", RestName.Restaurant.Name);

                Assert.Equal("Tip", ChefFirstName.Chef.FirstName);
                Assert.Equal("Harris", ChefLastName.Chef.LastName);
                Assert.Equal(444, RestID.Restaurant.ID);
            }
        }
    }
}
