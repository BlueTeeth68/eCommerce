using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Cart : BaseEntity
{
    [Range(0, 250)] public int Quantity { get; set; }

    [Precision(2)]
    [Range(0, int.MaxValue)]
    public decimal TotalPrice { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();
}