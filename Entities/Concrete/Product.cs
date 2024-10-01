namespace Entities.Concrete;

public class Product
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    
}