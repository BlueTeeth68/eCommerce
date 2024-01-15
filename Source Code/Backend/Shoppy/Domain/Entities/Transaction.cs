using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Generics;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Transaction : BaseEntity
{
    [StringLength(250)] public string? Note { get; set; }

    [Column(TypeName = "tinyint")] public TransactionType Type { get; set; } = TransactionType.Purchase;

    [Column(TypeName = "tinyint")] public PaymentType Method { get; set; }

    [StringLength(250)] public string? SourceAccount { get; set; }

    [StringLength(250)] public string? DestinationAccount { get; set; }

    [StringLength(250)] public string? TransactionCode { get; set; }

    [Column(TypeName = "tinyint")] public TransactionStatus Status { get; set; } = TransactionStatus.Pending;

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    [Precision(2)]
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public int? OrderId { get; set; }

    public virtual Order? Order { get; set; }
}