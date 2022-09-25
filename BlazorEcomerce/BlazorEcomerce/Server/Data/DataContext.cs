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
            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     Id = 1,
                     Title = "Title 1",
                     Description = "Description 3 Description 3 Description 3 Description 3 Description 3 ",
                     ImgURL = "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                     Price = 700
                 },

         new Product
         {
             Id = 2,
             Title = "Title 2",
             Description = "Description 3",
             ImgURL = "https://images.pexels.com/photos/768125/pexels-photo-768125.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             Price = 1200
         },

         new Product
         {
             Id = 3,
             Title = "Title 3",
             Description = "Description 3",
             ImgURL = "https://images.pexels.com/photos/2237801/pexels-photo-2237801.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             Price = 1300
         },
         new Product
         {
             Id = 4,
             Title = "Title 4",
             Description = "Description 4",
             ImgURL = "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             Price = 730
         },

         new Product
         {
             Id = 5,
             Title = "Title 5",
             Description = "Description 5",
             ImgURL = "https://images.pexels.com/photos/768125/pexels-photo-768125.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             Price = 23200
         },

         new Product
         {
             Id = 6,
             Title = "Title 6",
             Description = "Description 6",
             ImgURL = "https://images.pexels.com/photos/2237801/pexels-photo-2237801.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
             Price = 13320
         });
        }
        public DbSet<Product> Products { get; set; }    


    }
}
