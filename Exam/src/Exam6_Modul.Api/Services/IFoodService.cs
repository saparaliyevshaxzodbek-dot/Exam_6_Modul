using Exam6_Modul.Api.Dtos;
namespace Exam6_Modul.Api.Services;

public interface IFoodService
{
    Task<IEnumerable<FoodGetDto>> GetAllAsync();
    Task<FoodGetDto?> GetByIdAsync(int id);
    Task<IEnumerable<FoodGetDto>> GetByCategoryAsync(int categoryId);
    Task<IEnumerable<FoodGetDto>> GetAvailableAsync();
    Task<IEnumerable<FoodGetDto>> SearchByNameAsync(string name);
    Task<FoodGetDto?> CreateAsync(FoodCreateDto dto);
    Task<bool> UpdateAsync(int id, FoodUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
