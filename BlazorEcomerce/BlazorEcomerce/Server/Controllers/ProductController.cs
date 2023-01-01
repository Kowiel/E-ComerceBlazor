using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazroEcomerce.Shared.Models;
using BlazorEcomerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using BlazorEcomerce.Shared.Services;
using BlazorEcomerce.Server.IServices;
using BlazorEcomerce.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Claims;

namespace BlazorEcomerce.Server.Controllers
{
    
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;

        public ProductController(IProductService productservice)
        {
           _productservice = productservice;
        }
        [HttpGet("getalluser/", Name = "getalluser"), Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAllUserProducts()
        {
            var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _productservice.GetAllUserProducts(int.Parse(UserID));
            return Ok(result);
        }
        [HttpPost("create/", Name = "create"), Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<ServiceResponse<Product>>> CreateProduct(Product product)
        {
            var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _productservice.Create(product,int.Parse(UserID));
            return Ok(result);
        }

        [HttpPut("edit/", Name = "edit"), Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<ServiceResponse<Product>>> UpdateProduct(Product product)
        {
            var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier); 
          
            var result = await _productservice.Update(product, int.Parse(UserID));
            return Ok(result);
        }


        [HttpDelete("deleteone/{id}",Name = "delete"), Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteProduct(int id)
        {
            var result = await _productservice.Delete(id);
            return Ok(result);
        }

        [HttpGet("getalladmin/", Name = "getalladmin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAllAdminProducts()
        {
            var result = await _productservice.GetAllAdminProducts();
            return Ok(result);
        }

        [HttpGet("getall/", Name = "GetProduct")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct()
        {
            var response = await _productservice.GetAllProducts();
            return Ok(response); 
        }

        [HttpGet("getallfeatured/", Name = "GetFeaturedProduct")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProduct()
        {
            var response = await _productservice.GetAllFeturedProducts();
            return Ok(response);
        }

        [HttpGet("getone/{id}", Name = "GetOneProduct")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductByID(int id)
        {
            var response = await _productservice.GetProductByID(id);
            return Ok(response);
        }
        [HttpGet("getbycategory/{categoryURL}", Name = "GetProductsByCategory")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductByCategory(string categoryURL)
        {
            var response = await _productservice.GetProductByCategory(categoryURL);
            return Ok(response);
        }

        [HttpGet("getbyserchtext/{serchtext}/{category}/{CountOnPage}/{page}", Name = "GetProductsBySerchtext")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResultDTO>>> GetProductsBySerchtext(string serchtext, string Category, int page=1,int CountOnPage=3)
        {
            var response = await _productservice.SearchForProducts(serchtext,page,CountOnPage, Category);
            return Ok(response);
        }

        [HttpGet("getsugestionserchtext/{category}/{serchtext}", Name = "GetSugestionBySerchtext")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetSugestionBySerchtext(string serchtext,string Category)
        {
            var response = await _productservice.SearchForSugestions(serchtext, Category);
            return Ok(response);
        }
    }
}
