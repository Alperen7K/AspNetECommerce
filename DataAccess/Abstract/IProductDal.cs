using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO_s;

namespace DataAccess.Abstract;

public interface IProductDal : IEntityRepository<Product>
{
    List<ProductDetailDto> GetAllProductDetails();

    ProductDetailDto GetProductDetailById(int productId);

    Boolean AddProduct(Product product);

    Boolean UpdateProduct(Product product);

    Boolean DeleteProduct(Product product);
}