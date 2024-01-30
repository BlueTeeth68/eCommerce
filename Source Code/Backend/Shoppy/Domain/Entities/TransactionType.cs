using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(Name), IsUnique = true)]
public class TransactionType : BaseEntity
{
    [StringLength(50)] public string Name { get; set; } = null!;
}