using BlazorEcomerce.Shared.Models;

namespace BlazorEcomerce.Client.IService
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        List<Category> AdminCategories { get; set; }

        event Action CategorysLoaded;
        Task GetAllCategories();
        Task GetAllAdminCategories();
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int categoryId);
        Category CreateNewCategory();
    }
}
