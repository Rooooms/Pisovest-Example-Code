using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSV7.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string? EmployeeName { get; set; }
        public string? EmployeePosition { get; set; }
        public string? EmployeeMobileNumber { get; set; }

        public string? EmployeeEmail { get; set; }
        public string? EmployeeAddress { get; set; }
        public int EmployeeExpectedSalary { get; set; }

        public DateTime Datejoined { get; set; }

        [JsonIgnore]
        public Salary Salary { get; set; }

        



    }
}
