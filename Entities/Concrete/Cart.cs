namespace Entities.Concrete;

public class Cart
{
    public int CartId { get; set; }
    public int UserId { get; set; }
    public int[] ProductsIds { get; set; }
}