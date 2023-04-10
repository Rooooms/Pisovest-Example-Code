using Microsoft.EntityFrameworkCore;
using POSV7.Data;
using POSV7.Models;

namespace POSV7.Repository
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> Add(Employee employees)
        {
            try
            {
                _dataContext.Add(employees);
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
                var employees = await GetById(id);
                if (employees == null)
                {
                    return false;
                }
                _dataContext.Employees.Remove(employees);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dataContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            var employees = await _dataContext.Employees.FindAsync(id);
            return employees;
        }

        public async Task<bool> Update(Employee employees)
        {
            try
            {
                _dataContext.Update(employees);
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
