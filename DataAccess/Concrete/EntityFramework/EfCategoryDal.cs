using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCategoryDal : EfEntityRepositoryBase<Category, PostgreSqlContext>, ICategoryDal
{
    public List<Category> GetAllCategories()
    {
        throw new NotImplementedException();
    }

    public Category GetCategoryById(int categoryId)
    {
        throw new NotImplementedException();
    }

    public bool AddCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public bool UpdateCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public bool DeleteCategory(Category category)
    {
        throw new NotImplementedException();
    }
}