using Exam6_Modul.Api.Dtos;
using Exam6_Modul.Api.Entities;

namespace Exam6_Modul.Api.Mapping;

public class FoodMapper : ICustomMapper
{
    public FoodGetDto ToGetDto(Food food)
    {
        return new FoodGetDto
        {
            Id = food.Id,
            Name = food.Name,
            Description = food.Description,
            Price = food.Price,
            IsAvailable = food.IsAvailable,
            CreatedAt = food.CreatedAt,
            CategoryId = food.CategoryId,
            CategoryName = food.Category?.Name
        };
    }

    public Food ToEntity(FoodCreateDto dto)
    {
        return new Food
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            IsAvailable = dto.IsAvailable,
            CategoryId = dto.CategoryId
        };
    }

    public void MapToEntity(FoodUpdateDto dto, Food entity)
    {
        if (dto.Name is not null) entity.Name = dto.Name;
        if (dto.Description is not null) entity.Description = dto.Description;
        if (dto.Price is not null) entity.Price = dto.Price.Value;
        if (dto.IsAvailable is not null) entity.IsAvailable = dto.IsAvailable.Value;
        if (dto.CategoryId is not null) entity.CategoryId = dto.CategoryId.Value;
    }
}
