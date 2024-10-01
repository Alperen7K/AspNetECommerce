using Core.Entities;

namespace Entities.Concrete;

public class Cart:IEntity
{
    public int CartId { get; set; }
    public int UserId { get; set; }
}