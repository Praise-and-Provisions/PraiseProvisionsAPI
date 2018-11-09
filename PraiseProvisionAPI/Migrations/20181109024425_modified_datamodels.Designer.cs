﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PraiseProvisionsAPI.Data;

namespace PraiseProvisionAPI.Migrations
{
    [DbContext(typeof(PraiseDBContext))]
    [Migration("20181109024425_modified_datamodels")]
    partial class modified_datamodels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PraiseProvisionsAPI.Models.Chef", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChefImage");

                    b.Property<string>("City");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Chefs");

                    b.HasData(
                        new { ID = 1, City = "Albany", FirstName = "Paula", LastName = "Deen" },
                        new { ID = 2, City = "Los Angeles", FirstName = "Gordon", LastName = "Ramsey" },
                        new { ID = 3, City = "Jamaica", FirstName = "Jimmy", LastName = "Fallon" },
                        new { ID = 4, City = "Omaha", FirstName = "Jack", LastName = "TheRipper" }
                    );
                });

            modelBuilder.Entity("PraiseProvisionsAPI.Models.Favorites", b =>
                {
                    b.Property<int>("ChefID");

                    b.Property<int>("RestaurantID");

                    b.Property<string>("Reviews");

                    b.HasKey("ChefID", "RestaurantID");

                    b.HasIndex("RestaurantID");

                    b.ToTable("Favorites");

                    b.HasData(
                        new { ChefID = 3, RestaurantID = 1, Reviews = "This restaurant is amazing!" },
                        new { ChefID = 1, RestaurantID = 4, Reviews = "Gordon says terrible, terrible restaurant." }
                    );
                });

            modelBuilder.Entity("PraiseProvisionsAPI.Models.Restaurant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("RestaurantImage");

                    b.HasKey("ID");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new { ID = 1, Address = "1411 156th Ave NE, Ste A, Bellevue, WA 98007", City = "Seattle", Description = "Chinese, Hot Pot", Name = "The Pink Door" },
                        new { ID = 2, Address = "14330 Lake City Way NE, Seattle, WA 98125", City = "Portland", Description = "Southern, Soul Food, Fast Food", Name = "Tasty n Alder" },
                        new { ID = 3, Address = "700 Bellevue Way NE, Ste 280, Bellevue, WA 98004", City = "San Francisco", Description = "Taiwanese, Dim Sum, Shanghainese", Name = "Fog Harbor Fish House" },
                        new { ID = 4, Address = "2115 Westlake Ave, Seattle, WA 98121", City = "Los Angeles", Description = "Fast Food, American (Traditional), Burgers", Name = "Bestia" },
                        new { ID = 5, Address = "12405 SE 38th St, Bellevue, WA 98006", City = "New York", Description = "Steakhouses, Brazilian", Name = "Levain Bakery" }
                    );
                });

            modelBuilder.Entity("PraiseProvisionsAPI.Models.Favorites", b =>
                {
                    b.HasOne("PraiseProvisionsAPI.Models.Chef", "Chef")
                        .WithMany("Favorites")
                        .HasForeignKey("ChefID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PraiseProvisionsAPI.Models.Restaurant", "Restaurant")
                        .WithMany("Favorites")
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
