using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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

    public IDataResult<ProductDetailDto> GetById(int id)
    {
        var result = BusinessRules.Run(ProductExists(id));

        if (!result.Success) return new ErrorDataResult<ProductDetailDto>(result.Message);

        return new SuccessDataResult<ProductDetailDto>(_productDal.GetProductDetailById(id), Messages.ProductsListed);
    }

    public IDataResult<List<ProductDetailDto>> GetByCategory(int id)
    {
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetAllProductDetailsByCategory(id),Messages.ProductsListedByCategory);
    }

    public IDataResult<Product> Update(Product product)
    {
        var result = BusinessRules.Run(ProductExists(product.ProductId));

        if (!result.Success) return new ErrorDataResult<Product>(result.Message);

        _productDal.Update(product);

        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == product.ProductId),
            Messages.ProductUpdated);
    }

    public IResult Delete(int id)
    {
        var result = BusinessRules.Run(ProductExists(id));

        if (!result.Success) return new ErrorDataResult<Product>(result.Message);

        _productDal.Delete(_productDal.Get(p => p.ProductId == id));

        return new SuccessResult(Messages.ProductDeleted);
    }

    public IResult ProductExists(int id)
    {
        var isProductExists = _productDal.Get(p => p.ProductId == id);
        if (isProductExists != null) return new SuccessResult(Messages.ProductExists);

        return new ErrorResult(Messages.ProductDoesNotExist);
    }
}