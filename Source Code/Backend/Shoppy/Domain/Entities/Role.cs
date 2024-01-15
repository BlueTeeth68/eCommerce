using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Role:BaseEntity
{
    [StringLength(20)] public string Name { get; set; } = null!;
}