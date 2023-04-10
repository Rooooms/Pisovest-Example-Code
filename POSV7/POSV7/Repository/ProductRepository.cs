using Microsoft.EntityFrameworkCore;
using POSV7.Data;
using POSV7.Migrations;
using POSV7.Models;

namespace POSV7.Repository
{

    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Add(CreateProductDTO request)
        {
            var category = await _dataContext.Categories.FindAsync(request.CategoryId);
            if (category == null)
                return false;

            var newProduct = new Products
            {
                ProductName = request.ProductName,
                ProductBrand = request.ProductBrand,
                ProductDescription = request.ProductDescription,
                ProductModel = request.ProductModel,
                ProductPrice = request.ProductPrice,
                ProductQuantity = request.ProductQuantity,
              

                Category = category,
                CategoryName = category.CategoryName
            };  

            try
            {
                _dataContext.Add(newProduct);
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
                var products = await GetById(id);
                if (products == null)
                {
                    return false;
                }
                _dataContext.Products.Remove(products);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Products>> GetAll()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<List<Products>> GetByCategoryId(int categoryId)
        {
            var products = await _dataContext.Products.Where(c => c.CategoryId == categoryId).ToListAsync();

            return products;
        }

        public async Task<Products> GetById(int id)
        {
            var products = await _dataContext.Products.FindAsync(id);
            return products;
        }

        public async Task<bool> Update(Products products)
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
