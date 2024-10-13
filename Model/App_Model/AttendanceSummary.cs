using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class AttendanceSummary
    {
        [Key]
        public Guid Id { get; set; } // Primary Key
        public Guid EmpId { get; set; } // Foreign Key to Employee
        public Guid ComId { get; set; } // Foreign Key to Company
        public int Year { get; set; } // Example: 2024
        public int Month { get; set; } // Example: 9 (September)
        public int PresentDays { get; set; } // Example: 20 days
        public int LateDays { get; set; } // Example: 3 days
        public int AbsentDays { get; set; } // Example: 1 day
    }

}