using Exam6_Modul.Api.Dtos;
using Exam6_Modul.Api.Mapping;
using Exam6_Modul.Api.Repositories;

namespace Exam6_Modul.Api.Services;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _repo;
    private readonly FoodMapper _mapper;

    public FoodService(IFoodRepository repo, FoodMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FoodGetDto>> GetAllAsync()
    {
        var foods = await _repo.GetAllAsync();
        return foods.Select(f => _mapper.ToGetDto(f));
    }

    public async Task<FoodGetDto?> GetByIdAsync(int id)
    {
        var food = await _repo.GetByIdAsync(id);
        return food is null ? null : _mapper.ToGetDto(food);
    }

    public async Task<IEnumerable<FoodGetDto>> GetByCategoryAsync(int categoryId)
    {
        var foods = await _repo.GetByCategoryAsync(categoryId);
        return foods.Select(f => _mapper.ToGetDto(f));
    }

    public async Task<IEnumerable<FoodGetDto>> GetAvailableAsync()
    {
        var foods = await _repo.GetAvailableAsync();
        return foods.Select(f => _mapper.ToGetDto(f));
    }

    public async Task<IEnumerable<FoodGetDto>> SearchByNameAsync(string name)
    {
        var foods = await _repo.SearchByNameAsync(name);
        return foods.Select(f => _mapper.ToGetDto(f));
    }

    public async Task<FoodGetDto?> CreateAsync(FoodCreateDto dto)
    {
        var entity = _mapper.ToEntity(dto);
        var created = await _repo.AddAsync(entity);
        return _mapper.ToGetDto(created);
    }

    public async Task<bool> UpdateAsync(int id, FoodUpdateDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) return false;
        _mapper.MapToEntity(dto, existing);
        await _repo.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) return false;
        await _repo.DeleteAsync(existing);
        return true;
    }
}
