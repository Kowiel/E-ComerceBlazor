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
                    URL = "CAtegory_C"
                },
                  new Category
                {
                    Id = 5,
                    Name = "CD",
                    URL = "Category_D"
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
                     Featured=true,
                     Price=1,
                     UserId=7,
                 },

         new Product
         {
             Id = 2,
             Title = "Title 2",
             Description = "Description 3",
             ImgURL = "https://images.pexels.com/photos/768125/pexels-photo-768125.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             CategoryId = 1,
             Price = 2,
             UserId = 9,
         },

         new Product
         {
             Id = 3,
             Title = "Title 3",
             Description = "Description 3",
             ImgURL = "https://images.pexels.com/photos/2237801/pexels-photo-2237801.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
              CategoryId = 1,
             Price = 1,
             UserId = 7,
         },
         new Product
         {
             Id = 4,
             Title = "Title 4",
             Description = "Description 4",
             ImgURL = "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             CategoryId = 3,
             Price = 3,
             UserId = 9,
         },

         new Product
         {
             Id = 5,
             Title = "Title 5",
             Description = "Description 5",
             ImgURL = "https://images.pexels.com/photos/768125/pexels-photo-768125.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             CategoryId = 2,
             Price = 1,
             UserId = 7,
         },

         new Product
         {
             Id = 6,
             Title = "Title 6",
             Description = "Description 6",
             ImgURL = "https://images.pexels.com/photos/2237801/pexels-photo-2237801.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             CategoryId = 1,
             Price = 1,
             UserId = 7,
         },
           new Product
           {
               Id = 7,
               Title = "Pojazd 2",
               Description = "A great Fucking Car That exists",
               ImgURL = "https://static.bhphotovideo.com/explora/sites/default/files/styles/960/public/34-trvphoto-949-00184-reduced.png?itok=4A6wlBMA",
               CategoryId = 4,
               Featured=true,
               Price = 1,
               UserId = 7,
           },
           new Product
           {
               Id = 8,
               Title = "Pojazd 1",
               Description = "A decent Car that exists",
               ImgURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQDQeUbjwvSApFpWJ-EkBghl14Hwcx6vImu9VE4LzyFLKGNdB4627nZN_3e3DE8a9WXa4&usqp=CAU",
               CategoryId = 5,
               Featured =true,
               Price = 1,
               UserId = 7,
           },
           new Product
           {
               Id = 9,
               CategoryId = 3,
               Title = "Day of the Tentacle",
               Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
               ImgURL = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
               Price = 3,
               UserId = 9,

           },
                    new Product
                    {
                        Id = 10,
                        CategoryId = 3,
                        Title = "Xbox",
                        Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                        ImgURL = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                        Price = 1,
                        UserId = 7,
                    },
                    new Product
                    {
                        Id = 11,
                        CategoryId = 3,
                        Title = "Super Nintendo Entertainment System",
                        Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                        ImgURL = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                        Price = 1,
                        UserId = 7,

                    }


           );

          
        }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Category> Categorys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }


    }
}
