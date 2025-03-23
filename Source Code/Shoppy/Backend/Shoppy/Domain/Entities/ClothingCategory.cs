using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(Name), IsUnique = true)]
public class ClothingCategory : BaseEntity
{
    [StringLength(250)]
    public string Name { get; set; } = null!;
    
}