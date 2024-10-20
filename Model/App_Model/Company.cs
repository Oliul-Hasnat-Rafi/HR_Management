using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.Model.App_Model
{
    public class Company
    {
        [Key]
        public Guid ComId { get; set; }

        [Required, StringLength(100)]
        public string ComName { get; set; }

        [Range(0, 1)]
        public decimal Basic { get; set; }

        [Range(0, 1)]
        public decimal Hrent { get; set; }

        [Range(0, 1)]
        public decimal Medical { get; set; }

        public bool IsInactive { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<AttendanceSummary> AttendanceSummaries { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}