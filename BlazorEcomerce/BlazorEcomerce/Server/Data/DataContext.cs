using BlazorEcomerce.Shared.Models;
using BlazroEcomerce.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcomerce.Server.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductVariant>()
                .HasKey(e => new { e.ProductId , e.ProductTypeId} );
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id=1,Name="Default"},
                new ProductType { Id=2,Name="Poster"},
                new ProductType { Id=3,Name="CD"},
                new ProductType { Id=4,Name="Audiobook"},
                new ProductType { Id=5,Name="PaperBook"},
                new ProductType { Id=6,Name="MousePad"},
                new ProductType { Id=7,Name="Sticker"},
                new ProductType { Id=8,Name="NFT"},
                new ProductType { Id=9,Name="Sorce"},
                new ProductType { Id=10,Name="TEST"}


                );

            modelBuilder.Entity<Category>().HasData(
                
                new Category
                {
                    Id = 1,
                    Name = "Name1",
                    URL = "Name_One"
                },
                new Category
                {
                    Id = 2,
                    Name = "Name2",
                    URL = "Name_two"
                },
                new Category
                {
                    Id = 3,
                    Name = "Name3",
                    URL = "Name_three"
                },
                new Category
                {
                    Id = 4,
                    Name = "CC",
                    URL = "Christina_Carter"
                },
                  new Category
                {
                    Id = 5,
                    Name = "CD",
                    URL = "claire_dames"
                  }


                );
            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     Id = 1,
                     Title = "Title 1",
                     Description = "Description 3 Description 3 Description 3 Description 3 Description 3 ",
                     ImgURL = "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                     CategoryId = 1,
                 },

         new Product
         {
             Id = 2,
             Title = "Title 2",
             Description = "Description 3",
             ImgURL = "https://images.pexels.com/photos/768125/pexels-photo-768125.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             CategoryId = 1,
         },

         new Product
         {
             Id = 3,
             Title = "Title 3",
             Description = "Description 3",
             ImgURL = "https://images.pexels.com/photos/2237801/pexels-photo-2237801.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
              CategoryId = 1,
         },
         new Product
         {
             Id = 4,
             Title = "Title 4",
             Description = "Description 4",
             ImgURL = "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             CategoryId = 3,
         },

         new Product
         {
             Id = 5,
             Title = "Title 5",
             Description = "Description 5",
             ImgURL = "https://images.pexels.com/photos/768125/pexels-photo-768125.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             CategoryId = 2,
         },

         new Product
         {
             Id = 6,
             Title = "Title 6",
             Description = "Description 6",
             ImgURL = "https://images.pexels.com/photos/2237801/pexels-photo-2237801.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             CategoryId = 1,
         },
           new Product
           {
               Id = 7,
               Title = "Christina Carter",
               Description = "A great Fucking pornstar",
               ImgURL = "https://porn.tattoo/pics/legaction/christina-carter/completely-free-milf-vr/christina-carter-3.jpg",
               CategoryId = 4,
           },
           new Product
           {
               Id = 8,
               Title = "Claire Dames",
               Description = "A decent Fucking pornstar",
               ImgURL = "https://external-preview.redd.it/Ti6KimBa2vh2sqPnjwPpou6S_3F440TSO8UNeFXEt1I.jpg?auto=webp&s=4653334b5fc6f001e19a5b4a556be9b103d421a1",
               CategoryId = 5,
           },
           new Product
           {
               Id = 9,
               CategoryId = 3,
               Title = "Day of the Tentacle",
               Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
               ImgURL = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
            
           },
                    new Product
                    {
                        Id = 10,
                        CategoryId = 3,
                        Title = "Xbox",
                        Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                        ImgURL = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                    },
                    new Product
                    {
                        Id = 11,
                        CategoryId = 3,
                        Title = "Super Nintendo Entertainment System",
                        Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                        ImgURL = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                    }


           );

            modelBuilder.Entity<ProductVariant>().HasData(
                 new ProductVariant
                 {
                     ProductId = 1,
                     ProductTypeId = 2,
                     Price = 9.99m,
                     OriginalPrice = 19.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 1,
                     ProductTypeId = 3,
                     Price = 7.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 1,
                     ProductTypeId = 4,
                     Price = 19.99m,
                     OriginalPrice = 29.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 2,
                     ProductTypeId = 2,
                     Price = 7.99m,
                     OriginalPrice = 14.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 3,
                     ProductTypeId = 2,
                     Price = 6.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 4,
                     ProductTypeId = 5,
                     Price = 3.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 4,
                     ProductTypeId = 6,
                     Price = 9.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 4,
                     ProductTypeId = 7,
                     Price = 19.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 5,
                     ProductTypeId = 5,
                     Price = 3.99m,
                 },
                 new ProductVariant
                 {
                     ProductId = 6,
                     ProductTypeId = 5,
                     Price = 2.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 7,
                     ProductTypeId = 8,
                     Price = 19.99m,
                     OriginalPrice = 29.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 7,
                     ProductTypeId = 9,
                     Price = 69.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 7,
                     ProductTypeId = 10,
                     Price = 49.99m,
                     OriginalPrice = 59.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 8,
                     ProductTypeId = 8,
                     Price = 9.99m,
                     OriginalPrice = 24.99m,
                 },
                 new ProductVariant
                 {
                     ProductId = 9,
                     ProductTypeId = 8,
                     Price = 14.99m
                 },
                 new ProductVariant
                 {
                     ProductId = 10,
                     ProductTypeId = 1,
                     Price = 159.99m,
                     OriginalPrice = 299m
                 },
                 new ProductVariant
                 {
                     ProductId = 11,
                     ProductTypeId = 1,
                     Price = 79.99m,
                     OriginalPrice = 399m
                 }
             );
        }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Category> Categorys { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }


    }
}
