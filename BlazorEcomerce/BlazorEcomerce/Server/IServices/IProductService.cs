using BlazorEcomerce.Shared.DTOs;
using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;
using BlazroEcomerce.Shared.Models;

namespace BlazorEcomerce.Server.IServices
{
    public interface IProductService
    {
       public  Task<ServiceResponse<List<Product>>> GetAllProducts();
       public  Task<ServiceResponse<List<Product>>> GetAllFeturedProducts();
       public  Task<ServiceResponse<Product>> GetProductByID(int Id);
       public Task<ServiceResponse<ProductSearchResultDTO>> GetProductByCategory(string CategoryUrl, int PageNumber, int PageResults);
       public Task<ServiceResponse<ProductSearchResultDTO>> SearchForProducts(string SearchText, int PageNumber, int PageResults, string Category);
        public Task<ServiceResponse<List<string>>> SearchForSugestions(string Text, string Category);
        Task<ServiceResponse<List<Product>>> GetAllAdminProducts();
        Task<ServiceResponse<List<Product>>> GetAllUserProducts(int WhoId);
        Task<ServiceResponse<Product>> Create(Product product, int WhoId);
        Task<ServiceResponse<Product>> Update(Product product,int WhoId);
        Task<ServiceResponse<bool>> Delete(int productId);
    }
}
