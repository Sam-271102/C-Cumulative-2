using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolDatabaseMVP.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [Required]
        [RegularExpression(@"^T\d+$", ErrorMessage = "Employee Number must start with 'T' followed by digits.")]
        public string EmployeeNumber { get; set; }
    }
}
