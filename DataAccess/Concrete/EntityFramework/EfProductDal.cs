using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;

namespace DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, PostgreSqlContext>, IProductDal
{
    public List<ProductDetailDto> GetAllProductDetails()
    {
        using (PostgreSqlContext context = new PostgreSqlContext())
        {
            var result = from p in context.Products
                join c in context.Categories on p.CategoryId equals c.CategoryId
                select new ProductDetailDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    CategoryName = c.CategoryName,
                    CategoryId = c.CategoryId,
                    UnitPrice = p.UnitPrice,
                };
            return result.ToList();
        }
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