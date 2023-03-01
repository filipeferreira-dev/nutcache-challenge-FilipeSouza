using System.ComponentModel.DataAnnotations;

namespace NutcacheChallenge.ApplicationService.Employees.Messages
{
    public class EmployeeResponse
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string CPF { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        public int? Team { get; set; }
    }
}
