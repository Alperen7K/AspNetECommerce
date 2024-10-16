using Core.Entities;

namespace Entities.DTO_s;

public class ProductDetailDto : IDto
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public decimal UnitPrice { get; set; }
}