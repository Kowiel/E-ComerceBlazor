using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazroEcomerce.Shared.Models;
using BlazorEcomerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using BlazorEcomerce.Shared.Services;

namespace BlazorEcomerce.Server.Controllers
{
    
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("getall/", Name = "GetProduct")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct()
        {
            var Products = await _context.Products.ToListAsync();
            var response=new ServiceResponse<List<Product>>()
            {
                Value = Products
            };
            return Ok(response); 
        }
    }
}
