using Microsoft.EntityFrameworkCore;
using POSV7.Data;
using POSV7.Models;

namespace POSV7.Repository
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly DataContext _dataContext;
        public SalaryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> Add(CreateSalaryDTO request)
        {
            var employee = await _dataContext.Employees.FindAsync(request.EmployeeId);
            if (employee == null)
                return false;
            var newSalary = new Salary
            {
                Salaries = employee.EmployeeExpectedSalary,
                Deduction = request.Deduction,
                TotalSalary = employee.EmployeeExpectedSalary - request.Deduction,
                EmployeeName = employee.EmployeeName,


                Employee = employee,
                
            };

            try
            {
                _dataContext.Add(newSalary);
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
                var salaries = await GetById(id);
                if (salaries == null)
                {
                    return false;
                }
                _dataContext.Salaries.Remove(salaries);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Salary>> GetAll()
        {
            return await _dataContext.Salaries.ToListAsync();
        }

        public async Task<List<Salary>> GetByEmployeeId(int employeeId)
        {
            var salary = await _dataContext.Salaries.Where(c => c.EmployeeId == employeeId).ToListAsync();

            return salary;
        }

        public async Task<Salary> GetById(int id)
        {
            var salary = await _dataContext.Salaries.FindAsync(id);
            return salary;
        }

        public async Task<bool> Update(Salary salaries)
        {
            try
            {
                _dataContext.Update(salaries);
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
