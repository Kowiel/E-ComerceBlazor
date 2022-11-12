using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazroEcomerce.Shared.Models;
using BlazorEcomerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using BlazorEcomerce.Shared.Services;
using BlazorEcomerce.Server.IServices;
using BlazorEcomerce.Shared.DTOs;

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

        [HttpGet("getbyserchtext/{serchtext}/{CountOnPage}/{page}", Name = "GetProductsBySerchtext")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResultDTO>>> GetProductsBySerchtext(string serchtext,int page=1,int CountOnPage=3)
        {
            var response = await _productservice.SearchForProducts(serchtext,page,CountOnPage);
            return Ok(response);
        }

        [HttpGet("getsugestionserchtext/{serchtext}", Name = "GetSugestionBySerchtext")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetSugestionBySerchtext(string serchtext)
        {
            var response = await _productservice.SearchForSugestions(serchtext);
            return Ok(response);
        }
    }
}
