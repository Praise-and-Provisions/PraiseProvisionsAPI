using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PraiseProvisionAPI.Migrations
{
    public partial class final_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chefs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ChefImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    RestaurantImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    ChefID = table.Column<int>(nullable: false),
                    RestaurantID = table.Column<int>(nullable: false),
                    Reviews = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.ChefID, x.RestaurantID });
                    table.ForeignKey(
                        name: "FK_Favorites_Chefs_ChefID",
                        column: x => x.ChefID,
                        principalTable: "Chefs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Restaurants_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Chefs",
                columns: new[] { "ID", "ChefImage", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "https://cdn.vox-cdn.com/thumbor/wwYnkFN9L0OGT6gf5pUOfjcmy_s=/0x0:2000x1498/1200x800/filters:focal(877x266:1197x586)/cdn.vox-cdn.com/uploads/chorus_image/image/58429809/david_chang.0.jpg", "David", "Chang" },
                    { 2, "https://vegnews.com/media/W1siZiIsIjEyMjkzL1ZlZ05ld3NHb3Jkb25SYW1zYXkzLnBuZyJdLFsicCIsInRodW1iIiwiNjgweDQwMiMiLHsiZm9ybWF0IjoianBnIn1dLFsicCIsIm9wdGltaXplIl1d/VegNewsGordonRamsay3.png?sha=cfaa733eb7ada4e4", "Gordon", "Ramsey" },
                    { 3, "https://cdn.vox-cdn.com/thumbor/ejyNZqnfoNZY1kcCcGOb0xVJEW8=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/9439331/AUTHOR_PHOTO._RENE_REDZEPI._Photo_Credit_Laura_Lajh_Prijatelj.jpg", "Rene", "Redzepi" },
                    { 4, "https://cdn.japantimes.2xx.jp/wp-content/uploads/2014/09/p24-joe-jg-a-20140928.jpg", "Jean", "Georges" },
                    { 5, "https://s3-us-west-2.amazonaws.com/nnaka/wp-content/uploads/2016/02/07043256/nnaka_niki_nakayama.jpg", "Niki", "Nakayama" },
                    { 6, "https://pbs.twimg.com/profile_images/878592689595453442/WWbTrWHF.jpg", "Eddie", "Huang" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "ID", "Address", "City", "Description", "Name", "RestaurantImage" },
                values: new object[,]
                {
                    { 1, "2122 NE 65th St. Seattle, WA 98115", "Seattle", "Classic Southern fare made with heirloom ingredients is served in a stylish locale with cocktails.", "JuneBaby", "https://photos.smugmug.com/Seattle-Restaurant-Photography/2017/Junebaby/i-7sXBgZX/1/35d0094e/L/Pratt_Junebaby_006-L.jpg" },
                    { 2, "2404 NE 65th St, Seattle, WA 98115", "Seattle", "Eclectic menu featuring nose-to-tail local meats & creative veggie dishes in a contemporary room.", "Salare", "https://resizer.otstatic.com/v2/photos/large/25144284.jpg" },
                    { 3, "575 Henry St, Brooklyn, NY 11231", "Brooklyn", "Popular neighborhood eatery serves thin - crust pizza & guests bring their own wine & beer.", "Lucali", "https://pixel.nymag.com/imgs/daily/grub/2016/best-of-new-york/best-carrol-gardens-restaurant-lucali.w710.h473.jpg" },
                    { 4, "524 Court St, Brooklyn, NY 11231", "Brooklyn", "Quaint eatery offering a hearty American comfort - food menu & a popular weekend brunch.", "Buttermilk Channel", "https://www.tokyoweekender.com/wp-content/uploads/2018/10/%C3%A5%C2%A5%C3%A8h%C3%ACX%C3%AC%E2%80%A1%C3%A4%C5%93-1-1170x500.jpg" },
                    { 5, "2360, 1205 SW Washington St, Portland, OR 97205", "Portland", "Italian cafe serves handmade pastas in industrial digs amid a huge eagle mural & communal tables.", "Grassa", "https://res.cloudinary.com/sagacity/image/upload/c_crop/c_fit,h_640,w_960/6-13-grassa-opening_2_iqx7zu" },
                    { 6, "835 SW 2nd Ave, Portland, OR 97204", "Portland", "Popular counter - serve offering pho, banh mi & other Vietnamese favorites in a stylish setting.", "Luc Lac Vietnamese Kitchen", "https://img1.10bestmedia.com/Images/Photos/337486/IMG-7101_54_990x660.JPG" },
                    { 7, "214 Smith St, Brooklyn, NY 11201", "Brooklyn", "Classic neighborhood French bistro brings in crowds with its brunch & garden seating.", "Cafe Luluc", "http://ourbksocial.com/wp-content/uploads/2015/05/unnamed11.jpg" },
                    { 8, "178 Broadway, Brooklyn, NY 11211", "Brooklyn", "Iconic steakhouse where old-school waiters serve aged beef in a German beer hall setting.", "Peter Luger", "https://d1t295ks1d26ah.cloudfront.net/media/pictures/files/000/008/958/xlarge_desktop/x1.jpg?1424289053" }
                });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "ChefID", "RestaurantID", "Reviews" },
                values: new object[,]
                {
                    { 1, 1, "The best fried chicken you can get in the Pacific North West!" },
                    { 1, 2, "Must try the crispy duck leg with quinoa!" },
                    { 1, 3, "If it’s good enough for Jay-Z and Beyonce, it’s good enough for me!" },
                    { 3, 4, "The sort of joint we’d all like to have at the end of our street." },
                    { 5, 5, "Rotating menu with seasonal options, perfect portions and the best ingredients." },
                    { 4, 6, "This tucked away bistro, hardly one of PDX's best kept secrets, is a no-frills, saddle-up-to-the-bar-to-order kind of place." },
                    { 4, 7, "Perfect ambience, quality flavorful food and great service." },
                    { 6, 8, "A New York City steakhouse institution-- eating here is an experience unlike any other in the city." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_RestaurantID",
                table: "Favorites",
                column: "RestaurantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Chefs");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
