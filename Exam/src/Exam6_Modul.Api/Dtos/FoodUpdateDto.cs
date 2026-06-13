using System;

namespace Exam6_Modul.Api.Dtos
{
    public class FoodUpdateDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? IsAvailable { get; set; }
        public int? CategoryId { get; set; }
    }
}