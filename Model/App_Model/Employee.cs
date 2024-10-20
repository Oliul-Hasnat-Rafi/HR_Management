
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

        [Required, StringLength(20)]
        public string EmpCode { get; set; }

        [Required, StringLength(100)]
        public string EmpName { get; set; }

        public Guid ShiftId { get; set; }

        public Guid DeptId { get; set; }

        public Guid DesigId { get; set; }

        [Required, StringLength(10)]
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
        public virtual Company Company { get; set; }

        [ForeignKey("ShiftId")]
        public virtual Shift Shift { get; set; }

        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }

        [ForeignKey("DesigId")]
        public virtual Designation Designation { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<AttendanceSummary> AttendanceSummaries { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
    }


}