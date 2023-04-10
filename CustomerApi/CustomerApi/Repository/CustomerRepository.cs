using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;
        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> Add(Customer customers)
        {
            try
            {
                _dataContext.Add(customers);
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
                var customer = await GetById(id);
                if (customer == null)
                {
                    return false;
                }
                _dataContext.Customers.Remove(customer);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _dataContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _dataContext.Customers.FindAsync(id);
            return customer;
        }

        public async Task<bool> Update(Customer customers)
        {
            try
            {
                _dataContext.Update(customers);
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
