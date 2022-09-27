using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;

namespace BlazorEcomerce.Server.IServices
{
    public interface ICategoryService
    {
        public  Task<ServiceResponse<List<Category>>> GetAllCategorysAsync();
    }
}
