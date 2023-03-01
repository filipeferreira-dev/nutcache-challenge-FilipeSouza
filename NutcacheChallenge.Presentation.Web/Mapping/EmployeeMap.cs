using NutcacheChallenge.ApplicationService.Employees.Messages;
using NutcacheChallenge.Presentation.Web.Models;

namespace NutcacheChallenge.Presentation.Web.Mapping
{
    public static class EmployeeMap
    {

        public static EmployeeRequest Map(this Employee employee)
        {
            EmployeeRequest response = new()
            {
                Id = employee.Id,
                BirthDate = employee.BirthDate,
                CPF = employee.CPF,
                Email = employee.Email,
                Gender = employee.Gender,
                Name = employee.Name,
                StartDate = employee.StartDate,
                Team = employee.Team == null ? null : (int)employee.Team
            };

            return response;
        }

        public static Employee Map(this EmployeeResponse employee)
        {
            Employee response = new()
            {
                Id = employee.Id,
                BirthDate = employee.BirthDate,
                CPF = employee.CPF,
                Email = employee.Email,
                Gender = employee.Gender,
                Name = employee.Name,
                StartDate = employee.StartDate,
                Team = employee.Team != null ? (TeamEnum)employee.Team : null
            };

            return response;
        }

    }
}
