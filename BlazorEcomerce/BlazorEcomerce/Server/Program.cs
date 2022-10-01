using BlazorEcomerce.Server.Data;
using BlazorEcomerce.Server.IServices;
using BlazorEcomerce.Server.Services;
using BlazroEcomerce.Shared.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcomerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // DB

            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Db_Ecomerce")));



            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Add our Services
            // https://i.stack.imgur.com/M0le5.jpg
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();




            //Build APP!!
            var app = builder.Build();
            



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}