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
                    FirstName = "David",
                    LastName = "Chang",
                    ChefImage = "https://cdn.vox-cdn.com/thumbor/wwYnkFN9L0OGT6gf5pUOfjcmy_s=/0x0:2000x1498/1200x800/filters:focal(877x266:1197x586)/cdn.vox-cdn.com/uploads/chorus_image/image/58429809/david_chang.0.jpg"
                },
                new Chef
                {
                    ID = 2,
                    FirstName = "Gordon",
                    LastName = "Ramsey",
                    ChefImage = "https://vegnews.com/media/W1siZiIsIjEyMjkzL1ZlZ05ld3NHb3Jkb25SYW1zYXkzLnBuZyJdLFsicCIsInRodW1iIiwiNjgweDQwMiMiLHsiZm9ybWF0IjoianBnIn1dLFsicCIsIm9wdGltaXplIl1d/VegNewsGordonRamsay3.png?sha=cfaa733eb7ada4e4"
                },
                new Chef
                {
                    ID = 3,
                    FirstName = "Rene",
                    LastName = "Redzepi",
                    ChefImage = "https://cdn.vox-cdn.com/thumbor/ejyNZqnfoNZY1kcCcGOb0xVJEW8=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/9439331/AUTHOR_PHOTO._RENE_REDZEPI._Photo_Credit_Laura_Lajh_Prijatelj.jpg"
                },
                new Chef
                {
                    ID = 4,
                    FirstName = "Jean",
                    LastName = "Georges",
                    ChefImage = "https://cdn.japantimes.2xx.jp/wp-content/uploads/2014/09/p24-joe-jg-a-20140928.jpg"
                },
                new Chef
                {
                    ID = 5,
                    FirstName = "Niki",
                    LastName = "Nakayama",
                    ChefImage = "https://s3-us-west-2.amazonaws.com/nnaka/wp-content/uploads/2016/02/07043256/nnaka_niki_nakayama.jpg"
                },
                new Chef
                {
                    ID = 6,
                    FirstName = "Eddie",
                    LastName = "Huang",
                    ChefImage = "https://pbs.twimg.com/profile_images/878592689595453442/WWbTrWHF.jpg"
                },
                new Chef
                {
                    ID = 7,
                    FirstName = "Cathy",
                    LastName = "Whims",
                    ChefImage = "http://i0.wp.com/www.foodrepublic.com/wp-content/uploads/2015/10/Cathy-Head-Shot-J.-Valls.jpg?resize=700%2C1050"
                },
                new Chef
                {
                    ID = 8,
                    FirstName = "Eduoardo",
                    LastName = "Jordan",
                    ChefImage = "https://media1.fdncms.com/stranger/imager/u/original/23904087/1459784576-blackchefs-570.jpg"
                },
                new Chef
                {
                    ID = 9,
                    FirstName = "Rachel",
                    LastName = "Yang",
                    ChefImage = "https://i2.wp.com/eatsabroad.com/wp-content/uploads/2016/12/trove-chef-rachel-cropped-1.jpg?resize=696%2C523&ssl=1"
                }
            );

            mb.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    ID = 1,
                    Name = "JuneBaby",
                    Address = "2122 NE 65th St. Seattle, WA 98115",
                    Description = "Classic Southern fare made with heirloom ingredients is served in a stylish locale with cocktails.",
                    City = "Seattle",
                    RestaurantImage = "https://photos.smugmug.com/Seattle-Restaurant-Photography/2017/Junebaby/i-7sXBgZX/1/35d0094e/L/Pratt_Junebaby_006-L.jpg"
                },
                new Restaurant
                {
                    ID = 2,
                    Name = "Salare",
                    Address = "2404 NE 65th St, Seattle, WA 98115",
                    Description = "Eclectic menu featuring nose-to-tail local meats & creative veggie dishes in a contemporary room.",
                    City = "Seattle",
                    RestaurantImage = "https://resizer.otstatic.com/v2/photos/large/25144284.jpg"
                },
                new Restaurant
                {
                    ID = 3,
                    Name = "Lucali",
                    Address = "575 Henry St, Brooklyn, NY 11231",
                    Description = "Popular neighborhood eatery serves thin - crust pizza & guests bring their own wine & beer.",
                    City = "Brooklyn",
                    RestaurantImage = "https://pixel.nymag.com/imgs/daily/grub/2016/best-of-new-york/best-carrol-gardens-restaurant-lucali.w710.h473.jpg"
                },
                new Restaurant
                {
                    ID = 4,
                    Name = "Buttermilk Channel",
                    Address = "524 Court St, Brooklyn, NY 11231",
                    Description = "Quaint eatery offering a hearty American comfort - food menu & a popular weekend brunch.",
                    City = "Brooklyn",
                    RestaurantImage = "https://www.tokyoweekender.com/wp-content/uploads/2018/10/%C3%A5%C2%A5%C3%A8h%C3%ACX%C3%AC%E2%80%A1%C3%A4%C5%93-1-1170x500.jpg"
                },
                new Restaurant
                {
                    ID = 5,
                    Name = "Grassa",
                    Address = "2360, 1205 SW Washington St, Portland, OR 97205",
                    Description = "Italian cafe serves handmade pastas in industrial digs amid a huge eagle mural & communal tables.",
                    City = "Portland",
                    RestaurantImage = "https://res.cloudinary.com/sagacity/image/upload/c_crop/c_fit,h_640,w_960/6-13-grassa-opening_2_iqx7zu"
                },
                new Restaurant
                {
                    ID = 6,
                    Name = "Luc Lac Vietnamese Kitchen",
                    Address = "835 SW 2nd Ave, Portland, OR 97204",
                    Description = "Popular counter - serve offering pho, banh mi & other Vietnamese favorites in a stylish setting.",
                    City = "Portland",
                    RestaurantImage = "https://img1.10bestmedia.com/Images/Photos/337486/IMG-7101_54_990x660.JPG"
                },
                new Restaurant
                {
                    ID = 7,
                    Name = "Cafe Luluc",
                    Address = "214 Smith St, Brooklyn, NY 11201",
                    Description = "Classic neighborhood French bistro brings in crowds with its brunch & garden seating.",
                    City = "Brooklyn",
                    RestaurantImage = "http://ourbksocial.com/wp-content/uploads/2015/05/unnamed11.jpg"
                },
                new Restaurant
                {
                    ID = 8,
                    Name = "Peter Luger",
                    Address = "178 Broadway, Brooklyn, NY 11211",
                    Description = "Iconic steakhouse where old-school waiters serve aged beef in a German beer hall setting.",
                    City = "Brooklyn",
                    RestaurantImage = "https://d1t295ks1d26ah.cloudfront.net/media/pictures/files/000/008/958/xlarge_desktop/x1.jpg?1424289053"
                },
                new Restaurant
                {
                    ID = 9,
                    Name = "Il Corvo Pasta",
                    Address = "217 James Street, Seattle, WA, 98104",
                    Description = "Lunch-only Italian spot for homemade pastas served in a space decorated with antique tools.",
                    City = "Seattle",
                    RestaurantImage = "https://img.sunset02.com/sites/default/files/image/2013/06/inside-seattle-go-pioneer-square-corvo-pastas-pappardelle-0613-m.jpg"
                }, 
                new Restaurant
                {
                    ID = 10,
                    Name = "Canlis",
                    Address = "2576 Aurora Ave N, Seattle, WA 98109",
                    Description = "Landmark fine-dining destination (since 1950s) offering Pacific NW fare in a midcentury-modern home.",
                    City = "Seattle",
                    RestaurantImage = "http://winezag.com/wp-content/uploads/2009/07/canlis.jpg"
                },
                new Restaurant
                {
                    ID = 11,
                    Name = "Serious Pie",
                    Address = "316 Virginia St, Seattle, WA 98101",
                    Description = "Cozy restaurant with wood-fired, thin-crust gourmet pizzas, wine & beer served at communal tables.",
                    City = "Seattle",
                    RestaurantImage = "https://www.seriouspieseattle.com/uploads/_400x300_crop_center-center_65/both-pizzas_whole_birdseye.jpg"
                }
                
            );

            mb.Entity<Favorites>().HasData(
                new Favorites
                {
                    ChefID = 1,
                    RestaurantID = 1,
                    Reviews = "The best fried chicken you can get in the Pacific North West!"
                },
                new Favorites
                {
                    ChefID = 1,
                    RestaurantID = 2,
                    Reviews = "Must try the crispy duck leg with quinoa!"
                },
                new Favorites
                {
                    ChefID = 1,
                    RestaurantID = 3,
                    Reviews = "If it’s good enough for Jay-Z and Beyonce, it’s good enough for me!"
                },
                new Favorites
                {
                    ChefID = 3,
                    RestaurantID = 4,
                    Reviews = "The sort of joint we’d all like to have at the end of our street."
                },
                new Favorites
                {
                    ChefID = 5,
                    RestaurantID = 5,
                    Reviews = "Rotating menu with seasonal options, perfect portions and the best ingredients."
                },
                new Favorites
                {
                    ChefID = 4,
                    RestaurantID = 6,
                    Reviews = "This tucked away bistro, hardly one of PDX's best kept secrets, is a no-frills, saddle-up-to-the-bar-to-order kind of place."
                },
                new Favorites
                {
                    ChefID = 4,
                    RestaurantID = 7,
                    Reviews = "Perfect ambience, quality flavorful food and great service."
                },
                new Favorites
                {
                    ChefID = 6,
                    RestaurantID = 8,
                    Reviews = "A New York City steakhouse institution-- eating here is an experience unlike any other in the city."
                },
                new Favorites
                {
                    ChefID = 7,
                    RestaurantID = 9,
                    Reviews = "A tiny hole-in-the-wall pasta restaurant with a rotating selection of three different daily pastas, a casual atmosphere, and very fast service — even though there is always a line (queue) out the door. Mike Easton’s reverence of pasta is manifested in every bowl. I wish I had opened it myself."
                },
                new Favorites
                {
                    ChefID = 8,
                    RestaurantID = 10,
                    Reviews = "When I need to be spoiled or celebrate, this is the place to go. There’s really not much that needs to be said about the landmark of Seattle’s culinary scene. Steeped in history, Canlis exudes elegance and great service with food to match. This the place where happy times begin and end.."
                },
               new Favorites
               {
                   ChefID = 9,
                   RestaurantID = 11,
                   Reviews = "I actually really love Tom Douglas’s Serious Pie pizza. He definitely has great people working for him, his food is always solid, and the pizza’s great."
               }

            );
        }

        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Favorites> Favorites { get; set; }

    }
}
