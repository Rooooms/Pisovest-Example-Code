using POSV7.Data;
using POSV7.Models;
using Microsoft.EntityFrameworkCore;

namespace POSV7.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;
        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Add(Category categories)
        {
            

            try
            {
                _dataContext.Add(categories);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
                
          }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var category = await GetById(id);
                if (category == null)
                {
                    return false;
                }
                _dataContext.Categories.Remove(category);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {

            return await _dataContext.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _dataContext.Categories.FindAsync(id);
            return category;
        }

        public async Task<bool> Update(Category categories)
        {
            try
            {
                _dataContext.Update(categories);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
