using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Generics;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Order : BaseEntity
{
    [Column(TypeName = "tinyint")] public OrderStatus Status { get; set; }

    [Column(TypeName = "tinyint")] public PaymentType PaymentType { get; set; }

    [Range(0, int.MaxValue)] public decimal TotalPrice { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    [Precision(2)]
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Transaction? Transaction { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}