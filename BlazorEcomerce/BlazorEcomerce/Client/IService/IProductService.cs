
using BlazorEcomerce.Shared.Services;
using BlazroEcomerce.Shared.Models;

namespace BlazorEcomerce.Client.IService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Task GetAllProducts(string? CategoryURL=null);
        Task<ServiceResponse<Product>> GetProduct(int Id);

        event Action ProductChanged;

        string message { get; set; }

        Task SerchProducts(string searhText);
        Task<List<string>> GetProductSercheSugestion(string searhText);



    }
}
