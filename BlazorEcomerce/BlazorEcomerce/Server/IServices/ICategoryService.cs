﻿using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;

namespace BlazorEcomerce.Server.IServices
{
    public interface ICategoryService
    {
        public  Task<ServiceResponse<List<Category>>> GetAllCategorysAsync();
        public Task<ServiceResponse<List<Category>>> GetAllAdminCategories();
        public Task<ServiceResponse<List<Category>>> AddCategory(Category category);
        public Task<ServiceResponse<List<Category>>> UpdateCategory(Category category);
        public Task<ServiceResponse<List<Category>>> DeleteCategory(int id);
    }
}
