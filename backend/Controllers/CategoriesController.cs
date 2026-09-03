using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategory _category;

    public CategoriesController(ICategory category)
    {
        _category = category;
    }

    [HttpGet]
    public IActionResult GetAllCategory()
    {
        return Ok(_category.GetAllCategory());
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoryById(int id)
    {
        var category = _category.GetCategoryById(id);

        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public IActionResult AddCategory([FromBody] Category category)
    {
        return Ok(_category.AddCategory(category));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(
        int id,
        [FromBody] Category category)
    {
        category.Id = id;

        return Ok(_category.UpdateCategory(category));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategoryById(int id)
    {
        var result = _category.DeleteCategoryById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}