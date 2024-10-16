using Entities.DTO_s;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICategoryService
{
    IDataResult<List<Category>> GetAll();
    IResult Add(Category category);
    IDataResult<Category> Update(Category category);
    IResult Delete(int id);
    IResult CategoryExistByName(string name);
    IResult CategoryExistById(int id);
}