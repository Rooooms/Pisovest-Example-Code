using CustomerApi.Models;

namespace CustomerApi.Repository
{
    public interface ICustomerRepository
    {
        Task<bool> Add(Customer customers);
        Task<bool> Update(Customer customers);
        Task<Customer> GetById(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<Customer>> GetAll();
    }
}
