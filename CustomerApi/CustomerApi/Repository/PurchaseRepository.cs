using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DataContext _dataContext;
        public PurchaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Add(CreatePurchaseDTO request)
        {
            var product = await _dataContext.Products.FindAsync(request.ProductId);
            if (product == null)
                return false;

            var newPurchase = new Purchase
            {
                ProductName = request.ProductName,
                Price = request.Price,
                Quantity = request.Quantity,             
            };

            try
            {
                _dataContext.Add(newPurchase);
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
                var purchase = await GetById(id);
                if (purchase == null)
                {
                    return false;
                }
                _dataContext.Purchases.Remove(purchase);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Purchase>> GetAll()
        {
            return await _dataContext.Purchases.ToListAsync();
            
        }

        public async Task<Purchase> GetById(int id)
        {
            var purchase = await _dataContext.Purchases.FindAsync(id);
            return purchase;
        }

        public async Task<bool> Update(Purchase purchases)
        {
            try
            {
                _dataContext.Update(purchases);
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


