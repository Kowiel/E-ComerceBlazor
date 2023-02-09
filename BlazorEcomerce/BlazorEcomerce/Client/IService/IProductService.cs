
using BlazorEcomerce.Shared.Services;
using BlazroEcomerce.Shared.Models;

namespace BlazorEcomerce.Client.IService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        List<Product> AdminProducts { get; set; }
        Task GetAllProducts(string Category, int page, int CountOnPage);
        Task<ServiceResponse<Product>> GetProduct(int Id);

        event Action ProductChanged;

        string CurentCategory { get; set; }
        string message { get; set; }
        int CurentPageClient { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; }
        public bool ActiveCategorySerch { get; set; }

        Task SerchProducts(string searhText,string Category ,int ProductsOnPage ,int Page);
        Task<List<string>> GetProductSercheSugestion(string searhText , string Category);

        Task GetAllAdminProducts();
        Task GetAllUserProducts();
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(Product product);

    }
}
