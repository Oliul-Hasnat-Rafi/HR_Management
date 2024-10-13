
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Salary
    {
        [Key]
        public Guid Id { get; set; } // Primary Key
        public Guid ComId { get; set; } // Foreign Key to Company
        public Guid EmpId { get; set; } // Foreign Key to Employee
        public int Year { get; set; } // Example: 2024
        public int Month { get; set; } // Example: 9
        public decimal GrossSalary { get; set; }
        public decimal Basic { get; set; }
        public decimal HRent { get; set; }
        public decimal Medical { get; set; }
        public decimal AbsentAmount { get; set; } // (Basic / 30) * AbsentDays
        public decimal PayableAmount => GrossSalary - AbsentAmount;
        public bool IsPaid { get; set; } // True or False
        public decimal PaidAmount { get; set; } // Total Paid
    }

}
