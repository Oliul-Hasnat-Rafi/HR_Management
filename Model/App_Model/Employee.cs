
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Employee
    {
        [Key]
        public Guid EmpId { get; set; } 
        public Guid ComId { get; set; } 
        public string? EmpCode { get; set; } 
        public string ?EmpName { get; set; }

        public Guid ShiftId { get; set; } 
        public Guid DeptId { get; set; } 
        public Guid DesigId { get; set; }
        public string ?Gender { get; set; }
        public decimal GrossSalary { get; set; } 
        public DateTime JoinDate { get; set; } 

      
        public Company? Company { get; set; } 

        public decimal BasicSalary => GrossSalary * (Company?.BasicPercentage ?? 0);
        public decimal HRent => GrossSalary * (Company?.HRentPercentage ?? 0);
        public decimal Medical => GrossSalary * (Company?.MedicalPercentage ?? 0);
    }


}