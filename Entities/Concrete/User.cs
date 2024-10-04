using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete;

public class User : IEntity
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public bool Status { get; set; }
}