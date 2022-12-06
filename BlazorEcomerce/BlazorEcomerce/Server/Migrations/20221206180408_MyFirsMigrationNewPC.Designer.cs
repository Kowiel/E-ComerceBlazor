﻿// <auto-generated />
using System;
using BlazorEcomerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorEcomerce.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221206180408_MyFirsMigrationNewPC")]
    partial class MyFirsMigrationNewPC
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorEcomerce.Shared.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Name1",
                            URL = "Name_One"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Name2",
                            URL = "Name_two"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Name3",
                            URL = "Name_three"
                        },
                        new
                        {
                            Id = 4,
                            Name = "CC",
                            URL = "Christina_Carter"
                        },
                        new
                        {
                            Id = 5,
                            Name = "CD",
                            URL = "claire_dames"
                        });
                });

            modelBuilder.Entity("BlazorEcomerce.Shared.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Default"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Poster"
                        },
                        new
                        {
                            Id = 3,
                            Name = "CD"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Audiobook"
                        },
                        new
                        {
                            Id = 5,
                            Name = "PaperBook"
                        },
                        new
                        {
                            Id = 6,
                            Name = "MousePad"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Sticker"
                        },
                        new
                        {
                            Id = 8,
                            Name = "NFT"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Sorce"
                        },
                        new
                        {
                            Id = 10,
                            Name = "TEST"
                        });
                });

            modelBuilder.Entity("BlazorEcomerce.Shared.Models.ProductVariant", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<decimal?>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId", "ProductTypeId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductVariants");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 2,
                            OriginalPrice = 19.99m,
                            Price = 9.99m
                        },
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 3,
                            Price = 7.99m
                        },
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 4,
                            OriginalPrice = 29.99m,
                            Price = 19.99m
                        },
                        new
                        {
                            ProductId = 2,
                            ProductTypeId = 2,
                            OriginalPrice = 14.99m,
                            Price = 7.99m
                        },
                        new
                        {
                            ProductId = 3,
                            ProductTypeId = 2,
                            Price = 6.99m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 5,
                            Price = 3.99m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 6,
                            Price = 9.99m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 7,
                            Price = 19.99m
                        },
                        new
                        {
                            ProductId = 5,
                            ProductTypeId = 5,
                            Price = 3.99m
                        },
                        new
                        {
                            ProductId = 6,
                            ProductTypeId = 5,
                            Price = 2.99m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 8,
                            OriginalPrice = 29.99m,
                            Price = 19.99m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 9,
                            Price = 69.99m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 10,
                            OriginalPrice = 59.99m,
                            Price = 49.99m
                        },
                        new
                        {
                            ProductId = 8,
                            ProductTypeId = 8,
                            OriginalPrice = 24.99m,
                            Price = 9.99m
                        },
                        new
                        {
                            ProductId = 9,
                            ProductTypeId = 8,
                            Price = 14.99m
                        },
                        new
                        {
                            ProductId = 10,
                            ProductTypeId = 1,
                            OriginalPrice = 299m,
                            Price = 159.99m
                        },
                        new
                        {
                            ProductId = 11,
                            ProductTypeId = 1,
                            OriginalPrice = 399m,
                            Price = 79.99m
                        });
                });

            modelBuilder.Entity("BlazroEcomerce.Shared.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

                    b.Property<string>("ImgURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Description 3 Description 3 Description 3 Description 3 Description 3 ",
                            Featured = true,
                            ImgURL = "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Title = "Title 1"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Description 3",
                            Featured = false,
                            ImgURL = "https://images.pexels.com/photos/768125/pexels-photo-768125.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Title = "Title 2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Description 3",
                            Featured = false,
                            ImgURL = "https://images.pexels.com/photos/2237801/pexels-photo-2237801.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Title = "Title 3"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Description = "Description 4",
                            Featured = false,
                            ImgURL = "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Title = "Title 4"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Description 5",
                            Featured = false,
                            ImgURL = "https://images.pexels.com/photos/768125/pexels-photo-768125.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Title = "Title 5"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Description = "Description 6",
                            Featured = false,
                            ImgURL = "https://images.pexels.com/photos/2237801/pexels-photo-2237801.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Title = "Title 6"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 4,
                            Description = "A great Fucking pornstar",
                            Featured = true,
                            ImgURL = "https://porn.tattoo/pics/legaction/christina-carter/completely-free-milf-vr/christina-carter-3.jpg",
                            Title = "Christina Carter"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 5,
                            Description = "A decent Fucking pornstar",
                            Featured = true,
                            ImgURL = "https://external-preview.redd.it/Ti6KimBa2vh2sqPnjwPpou6S_3F440TSO8UNeFXEt1I.jpg?auto=webp&s=4653334b5fc6f001e19a5b4a556be9b103d421a1",
                            Title = "Claire Dames"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                            Featured = false,
                            ImgURL = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
                            Title = "Day of the Tentacle"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                            Featured = false,
                            ImgURL = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                            Title = "Xbox"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                            Featured = false,
                            ImgURL = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                            Title = "Super Nintendo Entertainment System"
                        });
                });

            modelBuilder.Entity("BlazorEcomerce.Shared.Models.ProductVariant", b =>
                {
                    b.HasOne("BlazroEcomerce.Shared.Models.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorEcomerce.Shared.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("BlazroEcomerce.Shared.Models.Product", b =>
                {
                    b.HasOne("BlazorEcomerce.Shared.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("BlazroEcomerce.Shared.Models.Product", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
