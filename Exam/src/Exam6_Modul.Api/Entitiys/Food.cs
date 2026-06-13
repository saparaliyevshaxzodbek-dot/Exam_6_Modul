namespace Exam6_Modul.Api.Entitiys;

public class Food
{
    public int FoodId { get; set; }

    
    public string Name { get; set; } = string.Empty;

  
    public string? Description { get; set; }

    
    public decimal Price { get; set; }

    
    public bool IsAvailable { get; set; }

  
    public int CategoryId { get; set; }

    
    public Category Category { get; set; } = null!;
}
