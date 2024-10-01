using Core.Entities;

namespace Entities.DTO_s;

public class UserForRegisterDto:IDto
{
    public string Email  { get; set; }
    public string Password  { get; set; }
    public string Name  { get; set; }
    public string SurName  { get; set; }
}