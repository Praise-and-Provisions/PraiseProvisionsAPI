using Microsoft.EntityFrameworkCore.Migrations;

namespace PraiseProvisionAPI.Migrations
{
    public partial class modified_datamodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestaurantImage",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChefImage",
                table: "Chefs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantImage",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ChefImage",
                table: "Chefs");
        }
    }
}
