using BlazorEcomerce.Server.Data;
using BlazorEcomerce.Server.IServices;
using BlazorEcomerce.Shared.Services;
using BlazroEcomerce.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcomerce.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Product>>> GetAllProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await _context.Products.ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductByCategory(string CategoryUrl)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await _context.Products.Where(x => x.category.URL.ToLower().Equals(CategoryUrl)).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductByID(int Id)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products.FindAsync(Id);
        
            if(product == null)
            {
                response.Success = false;
                response.ReturnMesage = "Item Not Found";
            }
            else
            {
                response.Success = true;
                response.ReturnMesage = "Product Found";
                response.Value = product;
            }
            return response;
        }
    }
}
