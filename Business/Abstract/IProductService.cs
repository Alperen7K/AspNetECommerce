using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTO_s;

namespace Business.Abstract;

public interface IProductService
{
    IResult Add(Product product);
    
    IDataResult<List<ProductDetailDto>> GetAll();
    
    IDataResult<Product> GetById(int id);
    
    IDataResult<List<Product>> GetByCategory(int id);
    
    IDataResult<Product> Update(Product product);
    
    IResult Delete(int id);
    
    IResult ProductExists(int id);
}