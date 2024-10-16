using Entities.DTO_s;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    private ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public IDataResult<List<Category>> GetAll()
    {
        return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoryListed);
    }

    public IResult Add(Category category)
    {
        var result = BusinessRules.Run(CategoryExistByName(category.CategoryName));

        if (!result.Success) return new ErrorResult(result.Message);

        _categoryDal.Add(category);
        return new SuccessResult(Messages.CategoryAdded);
    }

    public IDataResult<Category> Update(Category category)
    {
        var result = BusinessRules.Run(CategoryExistById(category.CategoryId));

        if (!result.Success) return new ErrorDataResult<Category>(result.Message);

        _categoryDal.Update(category);

        return new SuccessDataResult<Category>(Messages.CategoryUpdated);
    }

    public IResult Delete(int id)
    {
        var result = BusinessRules.Run(CategoryExistById(id));

        if (!result.Success) return new ErrorDataResult<Category>(result.Message);

        _categoryDal.Delete(new Category { CategoryId = id });
        return new SuccessResult(Messages.CategoryDeleted);
    }

    public IResult CategoryExistByName(string name)
    {
        var result = _categoryDal.Get(c => c.CategoryName == name);

        if (result != null) return new ErrorResult(Messages.CategoryExist);

        return new SuccessResult(Messages.CategoryNotExist);
    }

    public IResult CategoryExistById(int id)
    {
        var result = _categoryDal.Get(c => c.CategoryId == id);

        if (result != null) return new SuccessResult(Messages.CategoryExist);

        return new ErrorResult(Messages.CategoryNotExist);
    }
}