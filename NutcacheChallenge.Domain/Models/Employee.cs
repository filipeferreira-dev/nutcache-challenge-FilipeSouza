using NutcacheChallenge.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace NutcacheChallenge.Domain.Models
{
    public class Employee
    {
        [Key]
        public long Id { get; private set; }

        [Required]
        public string Name { get; private set; } = null!;

        [Required]
        public DateTime BirthDate { get; private set; }

        [Required]
        public string Gender { get; private set; } = null!;

        [Required]
        public string Email { get; private set; } = null!;

        [Required]
        public string CPF { get; private set; } = null!;

        [Required]
        public DateTime StartDate { get; private set; }

        public TeamEnum? Team { get; private set; }

        [Obsolete("EF only",true)]
        public Employee() { }

        public Employee(string name, DateTime birthDate, string gender, string email, string cpf, DateTime startDate, int? team = null)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Email = email;
            CPF = cpf;
            StartDate = startDate;
            Team = team != null ? (TeamEnum)team.Value : null;
        }

        public void Update(string name, DateTime birthDate, string gender, string email, string cpf, DateTime startDate, int? team = null)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Email = email;
            CPF = cpf;
            StartDate = startDate;
            Team = team != null ? (TeamEnum)team.Value : null;
        }
    }
}
