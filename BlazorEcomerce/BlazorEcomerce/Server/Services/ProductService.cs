using BlazorEcomerce.Client.Pages.AdminFolder;
using BlazorEcomerce.Server.Data;
using BlazorEcomerce.Server.IServices;
using BlazorEcomerce.Shared.DTOs;
using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;
using BlazroEcomerce.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BlazorEcomerce.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<Product>> Create(Product product, int WhoId)
        {
            var User = await _context.Users.FirstOrDefaultAsync(x => x.Id == WhoId);

            var dbProduct = new Product();

            if (User.Role == "User")
            {
                dbProduct.Title = product.Title;
                dbProduct.Description = product.Description;
                dbProduct.ImgURL = product.ImgURL;
                dbProduct.CategoryId = product.CategoryId;
                dbProduct.Featured = false;
                dbProduct.Price = product.Price;
                dbProduct.UserId = User.Id;
                dbProduct.CreatedDate = DateTime.Now;
                dbProduct.Visible = true;
                dbProduct.Deleted = false;
                dbProduct.Images = product.Images;
            }
            else if (User.Role == "Admin")
            {
                dbProduct.Title = product.Title;
                dbProduct.Description = product.Description;
                dbProduct.ImgURL = product.ImgURL;
                dbProduct.CategoryId = product.CategoryId;
                dbProduct.Featured = product.Featured;
                dbProduct.Price = product.Price;
                dbProduct.UserId = User.Id;
                dbProduct.CreatedDate = DateTime.Now;
                dbProduct.Visible = product.Visible;
                dbProduct.Deleted = false;
                dbProduct.Images = product.Images;
            }
                _context.Products.Add(dbProduct);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Product> { Value = product , ReturnMesage="Created a Prdouct",Success=true};
        }

        public async Task<ServiceResponse<bool>> Delete(int productId)
        {
            var dbProduct = await _context.Products.FindAsync(productId);
            if (dbProduct == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Value = false,
                    ReturnMesage = "Product not found."
                };
            }

            dbProduct.Deleted = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Value = true, Success = true, ReturnMesage = "Product Deleted" };
        }

        public async Task<ServiceResponse<Product>> Update(Product product, int WhoId)
        {
            var User = await _context.Users.FirstOrDefaultAsync(x => x.Id == WhoId);

            var dbProduct = await _context.Products
                  .Include(p => p.Images)
                  .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (dbProduct == null)
            {
                return new ServiceResponse<Product>
                {
                    Success = false,
                    ReturnMesage = "Product not found."
                };
            }
            if (User.Role == "User")
            {

                dbProduct.Title = product.Title;
                dbProduct.Description = product.Description;
                dbProduct.ImgURL = product.ImgURL;
                dbProduct.CategoryId = product.CategoryId;
                dbProduct.Visible = product.Visible;
                dbProduct.Price = product.Price;
                dbProduct.UpdatedDate = DateTime.Now;

                var ProductImages = dbProduct.Images;
                _context.Images.RemoveRange(ProductImages);
                dbProduct.Images = product.Images;


                await _context.SaveChangesAsync();
                return new ServiceResponse<Product> { Value = product };
            }
            else if(User.Role == "Admin")
            {
                dbProduct.Title = product.Title;
                dbProduct.Description = product.Description;
                dbProduct.ImgURL = product.ImgURL;
                dbProduct.CategoryId = product.CategoryId;
                dbProduct.Visible = product.Visible;
                dbProduct.Featured = product.Featured;
                dbProduct.Price = product.Price;
                dbProduct.UpdatedDate = DateTime.Now;

                var ProductImages = dbProduct.Images;
                _context.Images.RemoveRange(ProductImages);
                dbProduct.Images = product.Images;

                await _context.SaveChangesAsync();
                return new ServiceResponse<Product> { Value = product };
            }

            return new ServiceResponse<Product>
            {
                Success = false,
                ReturnMesage = "Error"
            };

        }
        public async Task<ServiceResponse<List<Product>>> GetAllAdminProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await _context.Products
               .Where(p => !p.Deleted)
               .Include(p => p.Images)
               .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetAllFeturedProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await _context.Products
                .Where(p => p.Featured && p.Visible && !p.Deleted)
                .Include(z => z.User)
                .Include(p => p.Images)
                .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetAllProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await _context.Products.Where(p => p.Visible && !p.Deleted).Include(p => p.Images)
                .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<ProductSearchResultDTO>> GetProductByCategory(string CategoryUrl, int PageNumber, int PageResults)
        {
            float pageresults=PageResults;
            double pageCount = Math.Ceiling((await GetProductsAsyncByCategoryURL(CategoryUrl)).Count / pageresults);

            var Products = await _context.Products.
            Where(x => x.category.URL.ToLower().Equals(CategoryUrl) && x.Visible && !x.Deleted)
            .Skip((PageNumber - 1) * (int)pageresults)
            .Take((int)pageresults)
            .Include(z => z.User)
            .Include(p => p.Images)
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

        private async Task<List<Product>> GetProductsAsyncByCategoryURL(string CategoryUrl)
        {
            var Value = await _context.Products.
             Where(x => x.category.URL.ToLower().Equals(CategoryUrl) && x.Visible && !x.Deleted)
             .ToListAsync();

            return Value;
        }

        public async Task<ServiceResponse<Product>> GetProductByID(int Id)
        {
            var response = new ServiceResponse<Product>();
            Product product = null;

            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.Products
                     .Include(z => z.User)
                     .Include(p => p.Images)
                    .FirstOrDefaultAsync(x => x.Id == Id && !x.Deleted);
            }
            else
            {
                product = await _context.Products
                    .Include(z => z.User)
                    .Include(p => p.Images)
                .FirstOrDefaultAsync(x => x.Id == Id && !x.Deleted && x.Visible);
            }

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
                var Products = await _context.Products.Where(x => x.Description.ToLower()
                .Contains(Text) && x.Visible && !x.Deleted || x.Title.ToLower().Contains(Text) && x.Visible && !x.Deleted)
                                 .Skip((PageNumber - 1) * (int)pageResult)
                                 .Take((int)pageResult)
                                 .Include(z => z.User)
                                 .Include(p => p.Images)
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
                var Products = await _context.Products.Where(x => x.Description.ToLower()
                .Contains(Text) && x.category.Name == Category && x.Visible && !x.Deleted || x.Title.ToLower().Contains(Text) && x.category.Name == Category && x.Visible && !x.Deleted)
                                 .Skip((PageNumber - 1) * (int)pageResult)
                                 .Take((int)pageResult)
                                 .Include(z => z.User)
                                 .Include(p => p.Images)
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

        private async Task<List<Product>> FindProductsByText(string Text , string Category)
        {
            if(Category=="All")
            {
                return await _context.Products.Where(x => x.Description.ToLower()
                .Contains(Text) && x.Visible && !x.Deleted || x.Title.ToLower()
                .Contains(Text) && x.Visible && !x.Deleted && x.Visible && !x.Deleted)
                           .Include(z => z.category)
                           .Include(z => z.User)
                           .ToListAsync();
            }
            else
            {
                return await _context.Products.Where(x => x.Description.ToLower()
                .Contains(Text) && x.category.Name == Category && x.Visible && !x.Deleted || x.Title.ToLower()
                .Contains(Text) && x.category.Name == Category && x.Visible && !x.Deleted && x.Visible && !x.Deleted)
                           .Include(z => z.category)
                           .Include(z => z.User)
                           .ToListAsync();
            }
           
        }

        

        public async Task<ServiceResponse<List<Product>>> GetAllUserProducts(int WhoId)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await _context.Products
               .Where(p => !p.Deleted && p.UserId==WhoId)
               .Include(p => p.Images)
               .ToListAsync()
            };
            return response;
        }
    }
}
