using POSV7.Models;

namespace POSV7.Repository
{
    public interface IProductRepository
    {
        Task<bool> Add(CreateProductDTO request);
        Task<bool> Update(Products products);
        Task<Products> GetById(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<Products>> GetAll();
        Task<List<Products>> GetByCategoryId (int categoryId);
    }
}
