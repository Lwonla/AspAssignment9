using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Entities;

public class UnitEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string Ingress { get; set; } = null!;
    public string? ImageUrl { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Price { get; set; }
    public string Category { get; set; } = null!;
}

//public int Quantity { get; set; }
//public string Tag { get; set; }


//public int Id { get; set; }
//public string Title { get; set; } = null!;
//public string? Description { get; set; }
//public string? ImageUrl { get; set; }

//[Column(TypeName = "money")]
//public decimal Price { get; set; }
