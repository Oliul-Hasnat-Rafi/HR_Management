
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Employee
    {
        [Key]
        public Guid EmpId { get; set; } // Primary Key
        public Guid ComId { get; set; } // Foreign Key to Company
        public string? EmpCode { get; set; } // Must be unique
        public string ?EmpName { get; set; }

        public Guid ShiftId { get; set; } // Foreign Key to Shift
        public Guid DeptId { get; set; } // Foreign Key to Department
        public Guid DesigId { get; set; } // Foreign Key to Designation
        public string ?Gender { get; set; }
        public decimal GrossSalary { get; set; } // User input
        public DateTime JoinDate { get; set; } // Joining date

        // Navigation property to Company
        public Company? Company { get; set; } // Reference to related company

        // Salary calculation based on company's percentages
        public decimal BasicSalary => GrossSalary * (Company?.BasicPercentage ?? 0);
        public decimal HRent => GrossSalary * (Company?.HRentPercentage ?? 0);
        public decimal Medical => GrossSalary * (Company?.MedicalPercentage ?? 0);
    }


}