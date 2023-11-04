using Tangy_Models;

namespace Tangy_Business.Repository.IRepository;

public interface ICategoryRepository
{
  public Task<CategoryDto> Create(CategoryDto category);
  public Task<CategoryDto> Update(CategoryDto category);
  public Task<int> Delete(int id);
  public Task<CategoryDto> GetById(int id);
  public Task<List<CategoryDto>> GetAll();
}
