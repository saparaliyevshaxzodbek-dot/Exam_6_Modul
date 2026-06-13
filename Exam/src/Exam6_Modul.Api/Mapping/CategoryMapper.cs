using Exam6_Modul.Api.Dtos;
using Exam6_Modul.Api.Entities;

namespace Exam6_Modul.Api.Mapping;

public class CategoryMapper : ICustomMapper
{
    public CategoryGetDto ToGetDto(Category category)
    {
        return new CategoryGetDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            IsActive = category.IsActive,
            CreatedAt = category.CreatedAt
        };
    }

    public Category ToEntity(CategoryCreateDto dto)
    {
        return new Category
        {
            Name = dto.Name,
            Description = dto.Description,
            IsActive = dto.IsActive
        };
    }

    public void MapToEntity(CategoryUpdateDto dto, Category entity)
    {
        if (dto.Name is not null) entity.Name = dto.Name;
        if (dto.Description is not null) entity.Description = dto.Description;
        if (dto.IsActive is not null) entity.IsActive = dto.IsActive.Value;
    }
}
