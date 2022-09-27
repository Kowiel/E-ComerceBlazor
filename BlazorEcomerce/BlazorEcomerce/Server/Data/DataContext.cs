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
                     Price = 700,
                     CategoryId = 1,
                 },

         new Product
         {
             Id = 2,
             Title = "Title 2",
             Description = "Description 3",
             ImgURL = "https://images.pexels.com/photos/768125/pexels-photo-768125.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             Price = 1200,
             CategoryId = 1,
         },

         new Product
         {
             Id = 3,
             Title = "Title 3",
             Description = "Description 3",
             ImgURL = "https://images.pexels.com/photos/2237801/pexels-photo-2237801.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             Price = 1300,
              CategoryId = 1,
         },
         new Product
         {
             Id = 4,
             Title = "Title 4",
             Description = "Description 4",
             ImgURL = "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             Price = 730,
             CategoryId = 3,
         },

         new Product
         {
             Id = 5,
             Title = "Title 5",
             Description = "Description 5",
             ImgURL = "https://images.pexels.com/photos/768125/pexels-photo-768125.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             Price = 23200,
             CategoryId = 2,
         },

         new Product
         {
             Id = 6,
             Title = "Title 6",
             Description = "Description 6",
             ImgURL = "https://images.pexels.com/photos/2237801/pexels-photo-2237801.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             Price = 13320,
             CategoryId = 1,
         },
           new Product
           {
               Id = 7,
               Title = "Christina Carter",
               Description = "A great Fucking pornstar",
               ImgURL = "https://porn.tattoo/pics/legaction/christina-carter/completely-free-milf-vr/christina-carter-3.jpg",
               Price = 100000000000,
               CategoryId = 4,
           },
           new Product
           {
               Id = 8,
               Title = "Claire Dames",
               Description = "A decent Fucking pornstar",
               ImgURL = "https://external-preview.redd.it/Ti6KimBa2vh2sqPnjwPpou6S_3F440TSO8UNeFXEt1I.jpg?auto=webp&s=4653334b5fc6f001e19a5b4a556be9b103d421a1",
               Price = 1000000000,
               CategoryId = 5,
           });
        }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Category> Categorys { get; set; }    


    }
}
