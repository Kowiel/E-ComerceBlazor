

using BlazorEcomerce.Client.IService;
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

        public event Action ProductChanged;

        public async Task GetAllProducts(string? CategoryURL = null)
        {
            
            var result = CategoryURL==null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/products/getall"):
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/products/getbycategory/{CategoryURL}");
            if (result != null && result.Value != null)
                Products = result.Value;

            ProductChanged?.Invoke();
        }

        public async Task<ServiceResponse<Product>> GetProduct(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/products/getone/{Id}");
            return result;
        }
    }
}
