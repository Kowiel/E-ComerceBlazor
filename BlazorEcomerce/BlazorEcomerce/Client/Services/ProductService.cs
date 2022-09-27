

using BlazorEcomerce.Client.IServices;
using BlazorEcomerce.Shared.Services;
using BlazroEcomerce.Shared.Models;
using System.Net.Http.Json;

namespace BlazorEcomerce.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();

        public async Task GetAllProducts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/products/getall");
            if (result != null && result.Value != null)
                Products = result.Value;
        }

        public async Task<ServiceResponse<Product>> GetProduct(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/products/getone/{Id}");
            return result;
        }
    }
}
