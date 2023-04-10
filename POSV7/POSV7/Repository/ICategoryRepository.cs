using POSV7.Models;

namespace POSV7.Repository
{
    public interface ICategoryRepository
    {
        Task<bool> Add(Category categories);
        Task<bool> Update(Category categories);
        Task<Category> GetById(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<Category>> GetAll();
    }
}
