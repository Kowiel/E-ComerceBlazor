﻿using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;
using BlazroEcomerce.Shared.Models;

namespace BlazorEcomerce.Server.IServices
{
    public interface IProductService
    {
       public  Task<ServiceResponse<List<Product>>> GetAllProducts();
       public  Task<ServiceResponse<Product>> GetProductByID(int Id);
        
       public Task<ServiceResponse<List<Product>>> GetProductByCategory(string CategoryUrl);
    }
}