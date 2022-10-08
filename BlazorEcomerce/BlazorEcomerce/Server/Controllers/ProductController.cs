using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazroEcomerce.Shared.Models;
using BlazorEcomerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using BlazorEcomerce.Shared.Services;
using BlazorEcomerce.Server.IServices;

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

        [HttpGet("getbyserchtext/{serchtext}", Name = "GetProductsBySerchtext")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsBySerchtext(string serchtext)
        {
            var response = await _productservice.SearchForProducts(serchtext);
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
