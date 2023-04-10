using System.Text.Json.Serialization;

namespace POSV7.Models
{
    public class Salary
    {
        public int Id { get; set; }

        public int Salaries { get; set; }

        public int Deduction { get; set; }

        public int TotalSalary { get; set; }

        public string? EmployeeName { get; set; }
        [JsonIgnore]
        public Employee? Employee { get; set; }

        public int EmployeeId { get; set; }
    }
}
