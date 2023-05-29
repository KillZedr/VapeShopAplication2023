using Microsoft.AspNetCore.Mvc;
using VSA.Domain;
using VSA.ServicesInterfaces;
using VSA.ServicesInterfaces.DTOs;



namespace VSA.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ManufacturerController : ControllerBase
{
    private readonly IManufacturerService _manufacturerService;

    public ManufacturerController(IManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetManufacturer(int id)
    {
        var manufacturer = await _manufacturerService.GetManufacturerAsync(id);
        return Ok(manufacturer);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllManufacturer()
    {
        var manufacturers = await _manufacturerService.GetAllManufacturerAsync();
        return Ok(manufacturers);
    }
    [HttpPost]

    public async Task<IActionResult> PostManufacturer([FromBody] CreateManufacturerDto manufacturerDtoModel)
    {
        Manufacturer result = await _manufacturerService.AddManufacturerAsync(manufacturerDtoModel);
        return Created($"/Manufacturers/{result.ManufacturerId}", result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateManufacturer([FromRoute] int id, [FromBody] EditManufacturerDto manufacturerDto)
    {
        var result = await _manufacturerService.UpdateManufacturerAsync(id, manufacturerDto);
        return Ok(result);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteManufacturer(int id)
    {
        await _manufacturerService.DeleteManufacturerAsync(id);
        return Ok();
    }

}