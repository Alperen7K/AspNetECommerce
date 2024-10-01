using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ICategoryDal : IEntityRepository<Category>
{
    List<Category> GetAllCategories();

    Category GetCategoryById(int categoryId);

    Boolean AddCategory(Category category);

    Boolean UpdateCategory(Category category);

    Boolean DeleteCategory(Category category);
}