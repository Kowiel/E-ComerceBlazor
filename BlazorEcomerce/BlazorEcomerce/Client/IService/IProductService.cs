﻿
using BlazorEcomerce.Shared.Services;
using BlazroEcomerce.Shared.Models;

namespace BlazorEcomerce.Client.IService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Task GetAllProducts(string? CategoryURL=null);
        Task<ServiceResponse<Product>> GetProduct(int Id);

        event Action ProductChanged;

        string CurentCategory { get; set; }
        string message { get; set; }
        int CurentPageClient { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; }

        Task SerchProducts(string searhText ,int ProductsOnPage ,int Page);
        Task<List<string>> GetProductSercheSugestion(string searhText);



    }
}
