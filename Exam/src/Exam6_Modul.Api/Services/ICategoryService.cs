using Exam6_Modul.Api.Dtos;
namespace Exam6_Modul.Api.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryGetDto>> GetAllAsync();
    Task<CategoryGetDto?> CreateAsync(CategoryCreateDto dto);
}
