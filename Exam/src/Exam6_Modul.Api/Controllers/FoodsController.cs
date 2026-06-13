using Exam6_Modul.Api.Dtos;
using Exam6_Modul.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exam6_Modul.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IFoodService _service;

    public FoodsController(IFoodService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var foods = await _service.GetAllAsync();
        return Ok(foods);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var food = await _service.GetByIdAsync(id);
        if (food is null) return NotFound();
        return Ok(food);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetByCategory(int categoryId)
    {
        var foods = await _service.GetByCategoryAsync(categoryId);
        return Ok(foods);
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailable()
    {
        var foods = await _service.GetAvailableAsync();
        return Ok(foods);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string name)
    {
        var foods = await _service.SearchByNameAsync(name);
        return Ok(foods);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FoodCreateDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created?.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] FoodUpdateDto dto)
    {
        var ok = await _service.UpdateAsync(id, dto);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}
