using POSV7.Models;

namespace POSV7.Repository
{
    public interface ISalaryRepository
    {
        Task<bool> Add(CreateSalaryDTO request);
        Task<bool> Update(Salary salaries);
        Task<Salary> GetById(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<Salary>> GetAll();
        Task<List<Salary>> GetByEmployeeId(int employeeId);
    }
}
