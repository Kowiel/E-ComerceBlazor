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
                Value = await _context.Products.Include(p => p.Variants).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductByCategory(string CategoryUrl)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await _context.Products.Where(x => x.category.URL.ToLower().Equals(CategoryUrl))
                .Include(p => p.Variants).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductByID(int Id)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products
                .Include(p=>p.Variants)
                .ThenInclude(v=>v.ProductType)
                .FirstOrDefaultAsync(p=>p.Id==Id);
        
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

        public async Task<ServiceResponse<List<Product>>> SearchForProducts(string SearchText)
        {
            string Text = SearchText.ToLower();
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await FindProductsByText(Text)

            };

            return response;
        }


        public async Task<ServiceResponse<List<string>>> SearchForSugestions(string Text)
        {
            var products = await FindProductsByText(Text);
            List<string> Sugestions = new List<string>();

            foreach (var item in products)
            {
                if(item.Title.Contains(Text,StringComparison.OrdinalIgnoreCase))
                {
                    Sugestions.Add(item.Title);
                }
                if (item.Description!=null)
                {
                    var punctiation = item.Description.Where(char.IsPunctuation).Distinct().ToArray();
                    var words =item.Description.Split().Select(s => s.Trim(punctiation));

                    foreach(var word in words)
                    {
                        if(word.Contains(Text,StringComparison.OrdinalIgnoreCase) && !Sugestions.Contains(word))
                        {
                            Sugestions.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Value = Sugestions };

        }

        //Methods not found un IServices
        private async Task<List<Product>> FindProductsByText(string Text)
        {
            return await _context.Products
                            .Where(x => x.Description.ToLower().Contains(Text) ||
                                x.Title.ToLower().Contains(Text))
                             .Include(p => p.Variants)
                            .ThenInclude(v => v.ProductType)
                            .ToListAsync();
        }

    }
}
