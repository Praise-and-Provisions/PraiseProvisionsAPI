using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PraiseProvisionAPI.Migrations
{
    public partial class dto : Migration
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
                    City = table.Column<string>(nullable: true)
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
                    Description = table.Column<string>(nullable: true)
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
                    RestaurantID = table.Column<int>(nullable: false)
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
                columns: new[] { "ID", "City", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Albany", "Paula", "Deen" },
                    { 2, "Los Angeles", "Gordon", "Ramsey" },
                    { 3, "Jamaica", "Jimmy", "Fallon" },
                    { 4, "Omaha", "Jack", "TheRipper" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "ID", "Address", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "1411 156th Ave NE, Ste A, Bellevue, WA 98007", "Chinese, Hot Pot", "Little Sheep Mongolian Hot Pot" },
                    { 2, "14330 Lake City Way NE, Seattle, WA 98125", "Southern, Soul Food, Fast Food ", "Heaven Sent Fried Chicken" },
                    { 3, "700 Bellevue Way NE, Ste 280, Bellevue, WA 98004", "Taiwanese, Dim Sum, Shanghainese", "Din Tai Fung" },
                    { 4, "2115 Westlake Ave, Seattle, WA 98121", "Fast Food, American (Traditional), Burgers", "Shake Shack" },
                    { 5, "12405 SE 38th St, Bellevue, WA 98006", "Steakhouses, Brazilian", "Novilhos Brazilian Steak House" }
                });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "ChefID", "RestaurantID" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "ChefID", "RestaurantID" },
                values: new object[] { 1, 4 });

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
