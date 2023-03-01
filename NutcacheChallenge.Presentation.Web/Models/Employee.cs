using System.ComponentModel.DataAnnotations;

namespace NutcacheChallenge.Presentation.Web.Models
{
    public class Employee
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string CPF { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public TeamEnum? Team { get; set; }
    }
}
