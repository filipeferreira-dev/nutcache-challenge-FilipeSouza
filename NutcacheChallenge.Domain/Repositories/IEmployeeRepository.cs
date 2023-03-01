using NutcacheChallenge.Domain.Models;

namespace NutcacheChallenge.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeByIdAsync(long id);

        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<Employee> CreateEmployeeAsync(Employee employee);

        Task<Employee> UpdateEmployeeAsync(Employee employee);

        Task DeleteEmployeeAsync(Employee employee);
    }
}
