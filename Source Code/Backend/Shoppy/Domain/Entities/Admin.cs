using Domain.Entities.Generics;

namespace Domain.Entities;

public class Admin:BaseEntity
{
    public int AccountId { get; set; }
    
    public Account Account { get; set; } = null!;
}