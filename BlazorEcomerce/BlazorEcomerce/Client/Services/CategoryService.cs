using BlazorEcomerce.Client.IService;
using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;
using System.Net.Http.Json;

namespace BlazorEcomerce.Client.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public event Action CategorysLoaded;

        public async Task GetAllCategories()
        {
            var response =  await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/categorys/getcategorys");
            if (response != null && response.Value != null)
            {
                Categories = response.Value;
            }
            CategorysLoaded?.Invoke();
        }
    }
}
