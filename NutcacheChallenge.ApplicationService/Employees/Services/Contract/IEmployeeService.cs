using NutcacheChallenge.ApplicationService.Employees.Messages;

namespace NutcacheChallenge.ApplicationService.Employees.Services.Contract
{
    public interface IEmployeeService
    {
        Task<EmployeeResponse> UpdateEmployeeAsync(EmployeeRequest employeeRequest);

        Task DeleteEmployeeAsync(long id);

        Task<EmployeeResponse> GetEmployeeByIdAsync(long id);

        Task<IEnumerable<EmployeeResponse>> GetAllEmployeesAsync();

        Task<EmployeeResponse> CreateEmployeeAsync(EmployeeRequest employeeRequest);
    }
}
