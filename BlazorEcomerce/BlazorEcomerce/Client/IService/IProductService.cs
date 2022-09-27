
using BlazorEcomerce.Shared.Services;
using BlazroEcomerce.Shared.Models;

namespace BlazorEcomerce.Client.IServices
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Task GetAllProducts();
        Task<ServiceResponse<Product>> GetProduct(int Id);
    }
}
