using Tangy_Models;

namespace Tangy_Business.Repository.IRepository;

public interface ICategoryRepository
{
  public CategoryDto Create(CategoryDto category);
  public CategoryDto Update(CategoryDto category);
  public int Delete(int id);
  public CategoryDto GetById(int id);
  public List<CategoryDto> GetAll();
}
