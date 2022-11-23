using BlazorEcomerce.Server.Data;
using BlazorEcomerce.Server.IServices;
using BlazorEcomerce.Shared.DTOs;
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

        public async Task<ServiceResponse<List<Product>>> GetAllFeturedProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await _context.Products.Where(x=>x.Featured==true).Include(p => p.Variants).ToListAsync()
            };
            return response;
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

        public async Task<ServiceResponse<ProductSearchResultDTO>> SearchForProducts(string SearchText , int PageNumber, int PageResults, string Category)
        {
            if (Category == "All")
            {
                float pageResult = PageResults;
                string Text = SearchText.ToLower();
                double pageCount = Math.Ceiling((await FindProductsByText(Text, Category)).Count / pageResult);
                var Products = await _context.Products
                                .Where(x => x.Description.ToLower().Contains(Text) ||
                                    x.Title.ToLower().Contains(Text))
                                 .Include(p => p.Variants)
                                 .Skip((PageNumber - 1) * (int)pageResult)
                                 .Take((int)pageResult)
                                 .ToListAsync();

                var response = new ServiceResponse<ProductSearchResultDTO>
                {
                    Value = new ProductSearchResultDTO
                    {
                        Products = Products,
                        CurentPage = PageNumber,
                        Pages = (int)pageCount
                    }

                };
                return response;
            }
            else
            {
                float pageResult = PageResults;
                string Text = SearchText.ToLower();
                double pageCount = Math.Ceiling((await FindProductsByText(Text,Category)).Count / pageResult);
                var Products = await _context.Products
                                .Where(x => x.Description.ToLower().Contains(Text) && x.category.Name == Category ||
                                    x.Title.ToLower().Contains(Text) && x.category.Name == Category)
                                 .Include(p => p.Variants)
                                 .Skip((PageNumber - 1) * (int)pageResult)
                                 .Take((int)pageResult)
                                 .ToListAsync();

                var response = new ServiceResponse<ProductSearchResultDTO>
                {
                    Value = new ProductSearchResultDTO
                    {
                        Products = Products,
                        CurentPage = PageNumber,
                        Pages = (int)pageCount
                    }

                };
                return response;
            }
            

           
        }

        public async Task<ServiceResponse<List<string>>> SearchForSugestions(string Text,string Category)
        {
            var products = await FindProductsByText(Text,Category);
            List<string> Sugestions = new List<string>();

            foreach (var item in products)
            {
                if (item.category.Name == Category||Category=="All")
                {
                    if (item.Title.Contains(Text, StringComparison.OrdinalIgnoreCase))
                    {
                        Sugestions.Add(item.Title);
                    }
                    if (item.Description != null)
                    {
                        var punctiation = item.Description.Where(char.IsPunctuation).Distinct().ToArray();
                        var words = item.Description.Split().Select(s => s.Trim(punctiation));

                        foreach (var word in words)
                        {
                            if (word.Contains(Text, StringComparison.OrdinalIgnoreCase) && !Sugestions.Contains(word))
                            {
                                Sugestions.Add(word);
                            }
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Value = Sugestions };

        }


        //Methods not found un IServices

        private async Task<List<Product>> FindProductsByText(string Text , string Category)
        {
            if(Category=="All")
            {
                return await _context.Products
                           .Where(x => x.Description.ToLower().Contains(Text)||
                               x.Title.ToLower().Contains(Text))
                            .Include(p => p.Variants)
                           .ThenInclude(v => v.ProductType)
                           .Include(z => z.category)
                           .ToListAsync();
            }
            else
            {
                return await _context.Products
                           .Where(x => x.Description.ToLower().Contains(Text) && x.category.Name == Category ||
                               x.Title.ToLower().Contains(Text) && x.category.Name == Category)
                            .Include(p => p.Variants)
                           .ThenInclude(v => v.ProductType)
                           .Include(z => z.category)
                           .ToListAsync();
            }
           
        }

    }
}
