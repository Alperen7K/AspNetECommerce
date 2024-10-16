using Business.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("category")]
[ApiController]
public class CategoryController : Controller
{
    private ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public ActionResult<AddCategoryDto> CreateCategory(Category category)
    {
        return Ok(_categoryService.Add(category));
    }

    [HttpPut]
    public ActionResult<Category> UpdateCategory(Category category)
    {
        return Ok(_categoryService.Update(category));
    }

    [HttpDelete("{id}")]
    public ActionResult<Category> DeleteCategory(int id)
    {
        return Ok(_categoryService.Delete(id));
    }

    [HttpGet]
    public ActionResult<List<Category>> GetAllCategories()
    {
        return Ok(_categoryService.GetAll());
    }
}