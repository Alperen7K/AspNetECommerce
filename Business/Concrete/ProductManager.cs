using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IResult Add(Product product)
    {
        _productDal.Add(product);

        return new SuccessResult(Messages.ProductAdded);
    }

    public IDataResult<List<ProductDetailDto>> GetAll()
    {
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetAllProductDetails(),
            Messages.ProductsListed);
    }

    public IDataResult<Product> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IDataResult<List<Product>> GetByCategory(int id)
    {
        throw new NotImplementedException();
    }

    public IDataResult<Product> Update(Product product)
    {
        throw new NotImplementedException();
    }

    public IResult Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IResult ProductExists(int id)
    {
        throw new NotImplementedException();
    }
}