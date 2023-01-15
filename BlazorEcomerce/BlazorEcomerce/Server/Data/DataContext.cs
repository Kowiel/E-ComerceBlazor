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
           
          
        }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Category> Categorys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }


    }
}
