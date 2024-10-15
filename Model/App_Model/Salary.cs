
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Salary
    {
        [Key]
        public Guid Id { get; set; } 
        public Guid ComId { get; set; } 
        public Guid EmpId { get; set; } 
        public int Year { get; set; } 
        public int Month { get; set; } 
        public decimal GrossSalary { get; set; }
        public decimal Basic { get; set; }
        public decimal HRent { get; set; }
        public decimal Medical { get; set; }
        public decimal AbsentAmount { get; set; } 
        public decimal PayableAmount => GrossSalary - AbsentAmount;
        public bool IsPaid { get; set; } 
        public decimal PaidAmount { get; set; } 
    }

}
