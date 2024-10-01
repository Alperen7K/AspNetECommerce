using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCartDal : EfEntityRepositoryBase<Cart, PostgreSqlContext>, ICartDal
{
    public List<Cart> GetCartsByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public Cart GetCartById(int cartId)
    {
        throw new NotImplementedException();
    }

    public bool CreateCart(Cart cart)
    {
        throw new NotImplementedException();
    }

    public bool UpdateCart(Cart cart)
    {
        throw new NotImplementedException();
    }

    public bool DeleteCart(Cart cart)
    {
        throw new NotImplementedException();
    }
}