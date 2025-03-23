using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(Name), IsUnique = true)]
public class BookCategory : BaseEntity
{
    [StringLength(50)] public string Name { get; set; } = null!;

    public virtual ICollection<Book>? Books { get; set; }
}