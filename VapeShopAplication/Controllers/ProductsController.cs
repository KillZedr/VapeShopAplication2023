using Microsoft.AspNetCore.Mvc;
using VSA.Domain;
using VSA.ServicesInterfaces;
using VSA.ServicesInterfaces.DTOs;



namespace VSA.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService _productService)
    {
        _productService = _productService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _productService.GetProductAsync(id);
        return Ok(product);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllGetProducts()
    {
        var products = await _productService.GetAllProductAsync();
        return Ok(products);
    }
    [HttpPost]

    public async Task<IActionResult> Post([FromBody] CreateProductDto productDtoModel)
    {
        Product result = await _productService.AddProductAsync(productDtoModel);
        return Created($"/Products/{result.ProductId}", result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] EditProductDto productDto)
    {
        var result = await _productService.UpdateProductAsync(id, productDto);
        return Ok(result);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProductAsync(id);
        return Ok();
    }

}

