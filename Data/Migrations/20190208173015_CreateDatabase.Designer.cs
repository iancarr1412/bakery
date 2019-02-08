﻿// <auto-generated />
using Bakery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bakery.Data.Migrations
{
    [DbContext(typeof(BakeryContext))]
    [Migration("20190208173015_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Bakery.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImageName")
                        .HasColumnName("ImageFileName");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A scrumptious mini-carrot cake encrusted with sliced almonds",
                            ImageName = "carrot_cake.jpg",
                            Name = "Carrot Cake",
                            Price = 8.99m
                        },
                        new
                        {
                            Id = 2,
                            Description = "A delicious lemon tart with fresh meringue cooked to perfection",
                            ImageName = "lemon_tart.jpg",
                            Name = "Lemon Tart",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Delectable vanilla and chocolate cupcakes",
                            ImageName = "cupcakes.jpg",
                            Name = "Cupcakes",
                            Price = 5.99m
                        },
                        new
                        {
                            Id = 4,
                            Description = "Fresh baked French-style bread",
                            ImageName = "bread.jpg",
                            Name = "Bread",
                            Price = 1.49m
                        },
                        new
                        {
                            Id = 5,
                            Description = "A glazed pear tart topped with sliced almonds and a dash of cinnamon",
                            ImageName = "pear_tart.jpg",
                            Name = "Pear Tart",
                            Price = 5.99m
                        },
                        new
                        {
                            Id = 6,
                            Description = "Rich chocolate frosting cover this chocolate lover's dream",
                            ImageName = "chocolate_cake.jpg",
                            Name = "Chocolate Cake",
                            Price = 8.99m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
