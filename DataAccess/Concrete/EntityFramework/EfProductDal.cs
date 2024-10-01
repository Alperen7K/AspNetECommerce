using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;

namespace DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, PostgreSqlContext>, IProductDal
{
    public List<ProductDetailDto> GetAllProductDetails()
    {
        throw new NotImplementedException();
    }

    public ProductDetailDto GetProductDetailById(int productId)
    {
        throw new NotImplementedException();
    }

    public bool AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public bool DeleteProduct(Product product)
    {
        throw new NotImplementedException();
    }
}