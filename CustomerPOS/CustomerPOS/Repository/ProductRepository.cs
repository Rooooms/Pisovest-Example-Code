using CustomerPOS.Data;
using CustomerPOS.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerPOS.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> Add(Product product)
        {
            try
            {
                _dataContext.Add(product);
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
                var product = await GetById(id);
                if (product == null)
                {
                    return false;
                }
                _dataContext.Products.Remove(product);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _dataContext.Products.FindAsync(id);
            return product;
        }

        

        public async Task<bool> Update(Product products)
        {
            try
            {
                _dataContext.Update(products);
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
