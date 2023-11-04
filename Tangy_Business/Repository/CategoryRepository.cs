using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository;

public class CategoryRepository : ICategoryRepository
{
  private readonly ApplicationDbContext _db;
  private readonly IMapper _mapper;

  public CategoryRepository(ApplicationDbContext db, IMapper mapper)
  {
    _db = db;
    _mapper = mapper;
  }

  public async Task<CategoryDto> Create(CategoryDto categoryDto)
  {
    var obj = _mapper.Map<Category>(categoryDto);
    obj.CreatedDate = DateTime.Now;

    await _db.Categories.AddAsync(obj);
    await _db.SaveChangesAsync();

    return _mapper.Map<CategoryDto>(obj);
  }

  public async Task<int> Delete(int id)
  {
    var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);

    if (obj != null)
    {
      _db.Categories.Remove(obj);
      return await _db.SaveChangesAsync();
    }

    return 0;
  }

  public async Task<List<CategoryDto>> GetAll()
  {
    return _mapper.Map<List<CategoryDto>>(await _db.Categories.ToListAsync());
  }

  public async Task<CategoryDto> GetById(int id)
  {
    var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);

    if (obj != null)
    {
      return _mapper.Map<CategoryDto>(obj);
    }

    return new CategoryDto();
  }

  public async Task<CategoryDto> Update(CategoryDto category)
  {
    var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

    if (obj != null)
    {
      obj.Name = category.Name;
      _db.Categories.Update(obj);
      await _db.SaveChangesAsync();

      return _mapper.Map<CategoryDto>(obj);
    }

    return category;
  }
}
