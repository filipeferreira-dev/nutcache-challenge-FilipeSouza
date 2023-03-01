using NutcacheChallenge.ApplicationService.Employees.Messages;
using NutcacheChallenge.Domain.Models;

namespace NutcacheChallenge.ApplicationService.Employees.Mappings
{
    public static class EmployeeMap
    {
        public static EmployeeResponse Map(this Employee employee)
        {
            EmployeeResponse response = new()
            {
                Id = employee.Id,
                BirthDate = employee.BirthDate,
                CPF = employee.CPF,
                Email = employee.Email,
                Gender = employee.Gender,
                Name = employee.Name,
                StartDate = employee.StartDate,
                Team = employee.Team != null ? (int)employee.Team : null
            };

            return response;
        }
    }
}
