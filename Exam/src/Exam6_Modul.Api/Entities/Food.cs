using System;

namespace Exam6_Modul.Api.Entities;

public class Food
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign key to Category
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
