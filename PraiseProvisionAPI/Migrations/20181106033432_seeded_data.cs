using Microsoft.EntityFrameworkCore.Migrations;

namespace PraiseProvisionsAPI.Migrations
{
    public partial class seeded_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
