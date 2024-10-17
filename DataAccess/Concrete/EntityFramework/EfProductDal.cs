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
        using (PostgreSqlContext context = new PostgreSqlContext())
        {
            var result = from p in context.Products
                join c in context.Categories on p.CategoryId equals c.CategoryId
                where c.CategoryId == categoryId
                select new ProductDetailDto
                {
                    ProductId = p.ProductId,
                    CategoryName = c.CategoryName,
                    CategoryId = c.CategoryId,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice,
                };
            return result.ToList();
        }
    }

    public ProductDetailDto GetProductDetailById(int productId)
    {
        using (PostgreSqlContext context = new PostgreSqlContext())
        {
            var result = (from p in context.Products
                join c in context.Categories on p.CategoryId equals c.CategoryId
                where p.ProductId == productId
                select new ProductDetailDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    CategoryName = c.CategoryName,
                    CategoryId = c.CategoryId,
                    UnitPrice = p.UnitPrice,
                }).FirstOrDefault();
            return result;
        }
    }
}