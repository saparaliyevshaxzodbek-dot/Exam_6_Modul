using Exam6_Modul.Api.Dtos;
using Exam6_Modul.Api.Entities;
using Exam6_Modul.Api.Mapping;
using Exam6_Modul.Api.Repositories;

namespace Exam6_Modul.Api.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repo;
    private readonly CategoryMapper _mapper;

    public CategoryService(ICategoryRepository repo, CategoryMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryGetDto>> GetAllAsync()
    {
        var categories = await _repo.GetAllAsync();
        return categories.Select(c => _mapper.ToGetDto(c));
    }

    public async Task<CategoryGetDto?> CreateAsync(CategoryCreateDto dto)
    {
        var entity = _mapper.ToEntity(dto);
        var created = await _repo.AddAsync(entity);
        return _mapper.ToGetDto(created);
    }
}
