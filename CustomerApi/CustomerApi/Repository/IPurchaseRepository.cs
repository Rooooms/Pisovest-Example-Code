using CustomerApi.Models;

namespace CustomerApi.Repository
{
    public interface IPurchaseRepository
    {
        Task<bool> Add(CreatePurchaseDTO request);
        Task<bool> Update(Purchase purchases);
        Task<Purchase> GetById(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<Purchase>> GetAll();
    }
}
