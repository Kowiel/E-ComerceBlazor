using BlazorEcomerce.Shared.Models;

namespace BlazorEcomerce.Client.IService
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        Task GetAllCategories();
    }
}
