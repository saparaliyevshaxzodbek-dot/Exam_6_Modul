using Exam6_Modul.Api.Data;
using Exam6_Modul.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam6_Modul.Api.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly AppDbContext _db;

    public FoodRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Food>> GetAllAsync()
    {
        return await _db.Foods.Include(f => f.Category).ToListAsync();
    }

    public async Task<Food?> GetByIdAsync(int id)
    {
        return await _db.Foods.Include(f => f.Category).FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<Food>> GetByCategoryAsync(int categoryId)
    {
        return await _db.Foods.Where(f => f.CategoryId == categoryId).Include(f => f.Category).ToListAsync();
    }

    public async Task<IEnumerable<Food>> GetAvailableAsync()
    {
        return await _db.Foods.Where(f => f.IsAvailable).Include(f => f.Category).ToListAsync();
    }

    public async Task<IEnumerable<Food>> SearchByNameAsync(string name)
    {
        return await _db.Foods.Where(f => f.Name.Contains(name)).Include(f => f.Category).ToListAsync();
    }

    public async Task<Food> AddAsync(Food food)
    {
        _db.Foods.Add(food);
        await _db.SaveChangesAsync();
        return food;
    }

    public async Task UpdateAsync(Food food)
    {
        _db.Foods.Update(food);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Food food)
    {
        _db.Foods.Remove(food);
        await _db.SaveChangesAsync();
    }
}
