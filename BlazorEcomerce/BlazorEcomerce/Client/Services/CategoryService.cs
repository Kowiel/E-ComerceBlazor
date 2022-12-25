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
        public List<Category> AdminCategories { get; set ; } = new List<Category>();

        public event Action CategorysLoaded;

        public async Task AddCategory(Category category)
        {
            var response = await _http.PostAsJsonAsync("api/categorys/adminpost", category);
            AdminCategories = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Category>>>()).Value;
            await GetAllCategories();
            CategorysLoaded?.Invoke();
        }

        public Category CreateNewCategory()
        {
            var newCategory = new Category { IsNew = true, Editing = true };
            AdminCategories.Add(newCategory);
            CategorysLoaded?.Invoke();
            return newCategory;
        }

        public async Task DeleteCategory(int categoryId)
        {
            var response = await _http.DeleteAsync($"api/categorys/admindelete/{categoryId}");
            AdminCategories = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Category>>>()).Value;
            await GetAllCategories();
            CategorysLoaded?.Invoke();
        }

        public async Task GetAllAdminCategories()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/categorys/adminget");
            if (response != null && response.Value != null)
                AdminCategories = response.Value;
        }

        public async Task GetAllCategories()
        {
            var response =  await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/categorys/getcategorys");
            if (response != null && response.Value != null)
            {
                Categories = response.Value;
            }
            CategorysLoaded?.Invoke();
        }

        public async Task UpdateCategory(Category category)
        {
            var response = await _http.PutAsJsonAsync("api/categorys/adminput", category);
            AdminCategories = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Category>>>()).Value;
            await GetAllCategories();
            CategorysLoaded?.Invoke();
        }
    }
}
