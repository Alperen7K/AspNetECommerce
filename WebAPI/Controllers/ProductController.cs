using Business.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("products")]
[ApiController]
public class ProductController : Controller
{
    private IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        return Ok(_productService.Add(product));
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll()
    {
        return Ok(_productService.GetAll());
    }

    [HttpPut]
    public ActionResult<Product> UpdateProduct(Product product)
    {
        return Ok(_productService.Update(product));
    }

    [HttpDelete("{id}")]
    public ActionResult<Product> DeleteProduct(int id)
    {
        return Ok(_productService.Delete(id));
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDetailDto> GetProductDetail(int id)
    {
        return Ok(_productService.GetById(id));
    }
}