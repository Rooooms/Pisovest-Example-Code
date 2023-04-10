using CustomerPOS.Models;

namespace CustomerPOS.Repository
{
    public interface IProductRepository
    {
        Task<bool> Add(Product product);
        Task<bool> Update(Product products);
        Task<Product> GetById(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<Product>> GetAll();
        
    }
}
