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

        public async Task<ServiceResponse<List<Category>>> AddCategory(Category category)
        {
            category.Editing = category.IsNew = false;
            _data.Categorys.Add(category);
            await _data.SaveChangesAsync();
            return await GetAllAdminCategories();
        }

        public async Task<ServiceResponse<List<Category>>> DeleteCategory(int id)
        {
            Category category = await GetCategoryById(id);
            if (category == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    ReturnMesage = "Category not found."
                };
            }

            category.Deleted = true;
            await _data.SaveChangesAsync();

            return await GetAllAdminCategories();
        }

        public async Task<ServiceResponse<List<Category>>> GetAllAdminCategories()
        {
            var response = await _data.Categorys.Where(c => !c.Deleted).ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Value = response
            };
        }
        public async Task<ServiceResponse<List<Category>>> GetAllCategorysAsync()
        {
            var response = await _data.Categorys.Where(c=>!c.Deleted && c.Visible).ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Value = response,
            };
        }
        public async Task<ServiceResponse<List<Category>>> UpdateCategory(Category category)
        {
            var dbCategory = await GetCategoryById(category.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    ReturnMesage = "Category not found."
                };
            }

            dbCategory.Name = category.Name;
            dbCategory.URL = category.URL;
            dbCategory.Visible = category.Visible;

            await _data.SaveChangesAsync();

            return await GetAllAdminCategories();
        }
        private async Task<Category> GetCategoryById(int id)
        {
            return await _data.Categorys.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
