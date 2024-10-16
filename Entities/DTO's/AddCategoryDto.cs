using Core.Entities;

namespace Entities.DTO_s;

public class AddCategoryDto:IDto
{
    public string CategoryName { get; set; }
}