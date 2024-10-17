using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTO_s;

namespace Business.Abstract;

public interface IProductService
{
    IResult Add(Product product);
    
    IDataResult<List<ProductDetailDto>> GetAll();
    
    IDataResult<ProductDetailDto> GetById(int id);
    
    IDataResult<List<ProductDetailDto>> GetByCategory(int id);
    
    IDataResult<Product> Update(Product product);
    
    IResult Delete(int id);
    
    IResult ProductExists(int id);
}