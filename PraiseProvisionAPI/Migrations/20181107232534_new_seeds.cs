using Microsoft.EntityFrameworkCore.Migrations;

namespace PraiseProvisionAPI.Migrations
{
    public partial class new_seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "City", "Name" },
                values: new object[] { "Seattle", "The Pink Door" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "City", "Description", "Name" },
                values: new object[] { "Portland", "Southern, Soul Food, Fast Food", "Tasty n Alder" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "City", "Name" },
                values: new object[] { "San Francisco", "Fog Harbor Fish House" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "City", "Name" },
                values: new object[] { "Los Angeles", "Bestia" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "City", "Description", "Name" },
                values: new object[] { "", "New York", "Levain Bakery" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Restaurants");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Little Sheep Mongolian Hot Pot");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Southern, Soul Food, Fast Food ", "Heaven Sent Fried Chicken" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Din Tai Fung");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 4,
                column: "Name",
                value: "Shake Shack");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Steakhouses, Brazilian", "Novilhos Brazilian Steak House" });
        }
    }
}
