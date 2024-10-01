using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ICartDal : IEntityRepository<Cart>
{
    List<Cart> GetCartsByUserId(int userId);

    Cart GetCartById(int cartId);

    Boolean CreateCart(Cart cart);

    Boolean UpdateCart(Cart cart);

    Boolean DeleteCart(Cart cart);
}