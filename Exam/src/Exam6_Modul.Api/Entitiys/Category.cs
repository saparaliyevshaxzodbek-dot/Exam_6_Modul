namespace Exam6_Modul.Api.Entitiys;

public class Category
{
    public int CategoryId { get; set; }

  
    public string Name { get; set; } = string.Empty;

   
    public ICollection<Food> Foods { get; set; } = new List<Food>();
}
