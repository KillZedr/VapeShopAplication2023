using Microsoft.AspNetCore.Mvc;
using VSA.Domain;
using VSA.ServicesInterfaces;
using VSA.ServicesInterfaces.DTOs;

namespace VSA.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);
            return Ok(category);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoryes = await _categoryService.GetAllCategoryAsync();
            return Ok(categoryes);
        }
        [HttpPost]

        public async Task<IActionResult> Post([FromBody] CreateCategoryDto categoryDtoModel)
        {
            Category result = await _categoryService.AddCategoryAsync(categoryDtoModel);
            return Created($"/Categoryes/{result.CategoryId}", result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory ([FromRoute] int id, [FromBody] EditCategoryDto category)
        {
            var result = await _categoryService.UpdateCategoryAsync(id, category);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory (int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
    
    }
}
