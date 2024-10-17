
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Employee
    {
        [Key]
        public Guid EmpId { get; set; }
        [Required]
        public Guid ComId { get; set; }
        [Required]
        public string EmpCode { get; set; }
        [Required]
        public string EmpName { get; set; }
        public Guid ShiftId { get; set; }
public String ? shiftName {get; set;}
        public Guid DeptId { get; set; }
        public String ? DeptName {get;set;}
        public Guid DesigId { get; set; }
        [Required]
        public String ? desigName {get; set;}

        public string Gender { get; set; }
        [Required]
        public decimal Gross { get; set; }
        public decimal Basic { get; set; }
        public decimal HRent { get; set; }
        public decimal Medical { get; set; }
        public decimal Others { get; set; }
        [Required]
        public DateTime DtJoin { get; set; }

        [ForeignKey("ComId")]
        public Company Company { get; set; }
        [ForeignKey("ShiftId")]
        public Shift Shift { get; set; }
        [ForeignKey("DeptId")]
        public Department Department { get; set; }
        [ForeignKey("DesigId")]
        public Designation Designation { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<AttendanceSummary> AttendanceSummaries { get; set; }
        public ICollection<Salary> Salaries { get; set; }
    }


}