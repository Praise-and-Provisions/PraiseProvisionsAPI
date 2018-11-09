using Microsoft.EntityFrameworkCore.Migrations;

namespace PraiseProvisionAPI.Migrations
{
    public partial class added_reviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reviews",
                table: "Favorites",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumns: new[] { "ChefID", "RestaurantID" },
                keyValues: new object[] { 1, 4 },
                column: "Reviews",
                value: "Gordon says terrible, terrible restaurant.");

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumns: new[] { "ChefID", "RestaurantID" },
                keyValues: new object[] { 3, 1 },
                column: "Reviews",
                value: "This restaurant is amazing!");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "City", "Description" },
                values: new object[] { "New York", "Steakhouses, Brazilian" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reviews",
                table: "Favorites");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "City", "Description" },
                values: new object[] { "", "New York" });
        }
    }
}
