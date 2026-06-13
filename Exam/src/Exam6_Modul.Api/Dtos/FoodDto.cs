namespace Exam6_Modul.Api.Dtos;

public class FoodDto
{
    public int FoodId { get; set; }

    
    public string Name { get; set; } = string.Empty;

   
    public string? Description { get; set; }


    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
}
