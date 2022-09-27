using BlazorEcomerce.Server.Data;
using BlazorEcomerce.Server.IServices;
using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcomerce.Server.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _data;

        public CategoryService(DataContext data)
        {
            _data = data;
        }
        public async Task<ServiceResponse<List<Category>>> GetAllCategorysAsync()
        {
            var response = await _data.Categorys.ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Value = response,
            };
        }
    }
}
