using FluentAssertions;
using NutcacheChallenge.Domain.Enums;
using NutcacheChallenge.Domain.Models;

namespace NutcacheChallenge.Domain.Test
{
    public class EmployeeTests
    {
        [Test]
        public void CreateEmployee_Success()
        {
            var name = "John Doe";
            var birthday = new DateTime(2000, 01, 01);
            var gender = "gender";
            var email = "email@test.com";
            var cpf = "12345678901";
            var startDate = new DateTime(2020, 01, 01);
            var team = (int)TeamEnum.Backend;

            var employee = new Employee(name, birthday, gender, email, cpf, startDate, team);

            // check if the employee was created
            employee.Should().NotBeNull();

            // check if the passed message
            employee.Name.Should().BeSameAs(name);
            employee.Email.Should().BeSameAs(email);
            employee.CPF.Should().BeSameAs(cpf);
            employee.BirthDate.Should().BeSameDateAs(birthday);
            employee.StartDate.Should().BeSameDateAs(startDate);
            employee.Team.Should().Be((TeamEnum)team);
        }
    }
}