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

    public List<ProductDetailDto> GetAllProductDetailsByCategory(int categoryId)
    {
        throw new NotImplementedException();
    }

    public ProductDetailDto GetProductDetailById(int productId)
    {
        throw new NotImplementedException();
    }
}