using NutcacheChallenge.ApplicationService.Employees.Mappings;
using NutcacheChallenge.ApplicationService.Employees.Messages;
using NutcacheChallenge.ApplicationService.Employees.Services.Contract;
using NutcacheChallenge.Domain.Models;
using NutcacheChallenge.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace NutcacheChallenge.ApplicationService.Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository EmployeeRepository { get; }

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        public async Task DeleteEmployeeAsync(long id)
        {
            var employee = await EmployeeRepository.GetEmployeeByIdAsync(id);

            if (employee == null) throw new ValidationException("Employee not found");

            await EmployeeRepository.DeleteEmployeeAsync(employee);
        }

        public async Task<IEnumerable<EmployeeResponse>> GetAllEmployeesAsync()
        {
            var employees = await EmployeeRepository.GetAllEmployeesAsync();

            if (!employees.Any()) return Enumerable.Empty<EmployeeResponse>();

            return employees.Select(employee => new EmployeeResponse()
            {
                Id = employee.Id,
                BirthDate = employee.BirthDate,
                CPF = employee.CPF,
                Email = employee.Email,
                Gender = employee.Gender,
                Name = employee.Name,
                StartDate = employee.StartDate,
                Team = employee.Team != null ? (int)employee.Team : null
            }).ToList();
        }

        public async Task<EmployeeResponse> GetEmployeeByIdAsync(long id)
        {
            var employee = await EmployeeRepository.GetEmployeeByIdAsync(id);

            if (employee == null) throw new ValidationException("Employee not found");

            return employee.Map();
        }

        public async Task<EmployeeResponse> UpdateEmployeeAsync(EmployeeRequest request)
        {
            if (!request.Id.HasValue) throw new ValidationException("Id cannot be null");

            var employee = await EmployeeRepository.GetEmployeeByIdAsync(request.Id.Value);

            if (employee == null) throw new ValidationException("Employee not found");

            employee.Update(request.Name, request.BirthDate, request.Gender, request.Email, request.CPF, request.StartDate, request.Team);

            await EmployeeRepository.UpdateEmployeeAsync(employee);

            return employee.Map();
        }

        public async Task<EmployeeResponse> CreateEmployeeAsync(EmployeeRequest request)
        {
            var entity = new Employee(request.Name, request.BirthDate, request.Gender, request.Email, request.CPF, request.StartDate, request.Team);

            var employee = await EmployeeRepository.CreateEmployeeAsync(entity);

            return employee.Map();
        }
    }
}
