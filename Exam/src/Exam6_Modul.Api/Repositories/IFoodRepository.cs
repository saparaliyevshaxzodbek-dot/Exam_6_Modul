using Exam6_Modul.Api.Entities;
namespace Exam6_Modul.Api.Repositories;

public interface IFoodRepository
{
    Task<IEnumerable<Food>> GetAllAsync();
    Task<Food?> GetByIdAsync(int id);
    Task<IEnumerable<Food>> GetByCategoryAsync(int categoryId);
    Task<IEnumerable<Food>> GetAvailableAsync();
    Task<IEnumerable<Food>> SearchByNameAsync(string name);
    Task<Food> AddAsync(Food food);
    Task UpdateAsync(Food food);
    Task DeleteAsync(Food food);
}
