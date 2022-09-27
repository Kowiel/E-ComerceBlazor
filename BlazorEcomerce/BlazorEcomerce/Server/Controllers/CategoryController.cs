using BlazorEcomerce.Server.IServices;
using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcomerce.Server.Controllers
{
    [ApiController]
    [Route("api/categorys")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }   

        [HttpGet("getcategorys/",Name ="GetAllCategories" )]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategorysAsync()
        {
            var respone = await _categoryService.GetAllCategorysAsync();
            return Ok(respone);
        }

    }
}
