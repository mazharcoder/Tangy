using AutoMapper;
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

  public CategoryDto Create(CategoryDto categoryDto)
  {
    var obj = _mapper.Map<Category>(categoryDto);
    obj.CreatedDate = DateTime.Now;

    _db.Categories.Add(obj);
    _db.SaveChanges();

    return _mapper.Map<CategoryDto>(obj);
  }

  public int Delete(int id)
  {
    var obj = _db.Categories.FirstOrDefault(x => x.Id == id);

    if (obj != null)
    {
      _db.Categories.Remove(obj);
      return _db.SaveChanges();
    }

    return 0;
  }

  public List<CategoryDto> GetAll()
  {
    return _mapper.Map<List<CategoryDto>>(_db.Categories.ToList());
  }

  public CategoryDto GetById(int id)
  {
    var obj = _db.Categories.FirstOrDefault(x => x.Id == id);

    if (obj != null)
    {
      return _mapper.Map<CategoryDto>(obj);
    }

    return new CategoryDto();
  }

  public CategoryDto Update(CategoryDto category)
  {
    var obj = _db.Categories.FirstOrDefault(x => x.Id == category.Id);

    if (obj != null)
    {
      obj.Name = category.Name;
      _db.Categories.Update(obj);
      _db.SaveChanges();

      return _mapper.Map<CategoryDto>(obj);
    }

    return category;
  }
}
