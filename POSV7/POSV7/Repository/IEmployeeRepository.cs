using POSV7.Models;

namespace POSV7.Repository
{
    public interface IEmployeeRepository
    {
        Task<bool> Add(Employee employees);
        Task<bool> Update(Employee employees);
        Task<Employee> GetById(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<Employee>> GetAll();
    }
}
