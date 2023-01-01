

using BlazorEcomerce.Client.IService;
using BlazorEcomerce.Shared.DTOs;
using BlazorEcomerce.Shared.Services;
using BlazroEcomerce.Shared.Models;
using System.Net.Http.Json;

namespace BlazorEcomerce.Client.Service
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public string message { get; set; } = "Loading Products ....";
        public string CurentCategory { get; set; } = String.Empty;
        public int CurentPageClient { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set;}=String.Empty;
        public List<Product> AdminProducts { get; set; }

        public event Action ProductChanged;

        public async Task<Product> CreateProduct(Product product)
        {
            var result = await _http.PostAsJsonAsync("api/products/create", product);
            var newProduct = (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Product>>()).Value;
            return newProduct;
        }

        public async Task DeleteProduct(Product product)
        {
            var result = await _http.DeleteAsync($"api/products/deleteone/{product.Id}");
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await _http.PutAsJsonAsync($"api/products/edit", product);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Product>>();
            return content.Value;
        }

        public async Task GetAllAdminProducts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/products/getalladmin");
            AdminProducts = result.Value;
            CurentPageClient = 1;
            PageCount = 0;
            if (AdminProducts.Count == 0)
                message = "No products found.";
        }

        public async Task GetAllProducts(string Category )
        {
            LastSearchText = String.Empty;
            if (Category != null)
                CurentCategory = Category;
            var result = Category==null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/products/getallfeatured"):
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/products/getbycategory/{Category}");
            if (result != null && result.Value != null)
                Products = result.Value;
            CurentPageClient = 1;
            PageCount = 0;

            if (Products.Count == 0)
                message = "No products";

            ProductChanged?.Invoke();
        }

        public async Task<ServiceResponse<Product>> GetProduct(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/products/getone/{Id}");
            return result;
        }

        public async Task<List<string>> GetProductSercheSugestion(string searhText, string Category) 
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/products/getsugestionserchtext/{Category}/{searhText}");
            return result.Value;
        }

        public async Task SerchProducts(string serchtext,string Category, int CountOnPage, int page) 
        {
            LastSearchText = serchtext;
            CurentCategory = Category;
            var result = await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResultDTO>>($"api/products/getbyserchtext/{serchtext}/{Category}/{CountOnPage}/{page}");
            if (result != null && result.Value != null)
            {
                Products = result.Value.Products;
                CurentPageClient = result.Value.CurentPage;
                PageCount = result.Value.Pages;
            }
               
            if (Products.Count == 0)
                message = "No products None";
            ProductChanged?.Invoke();
        }

        public async Task GetAllUserProducts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/products/getalluser");
            AdminProducts = result.Value;
            CurentPageClient = 1;
            PageCount = 0;
            if (AdminProducts.Count == 0)
                message = "No products found.";
        }
    }
}
