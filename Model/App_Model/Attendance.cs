using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Attendance
    {
        [Key]
        public Guid Id { get; set; } // Primary Key
        public Guid ComId { get; set; } // Foreign Key to Company
        public Guid EmpId { get; set; } // Foreign Key to Employee
        public DateTime Date { get; set; } // Example: 01-Sep-2024
        public string? AttStatus { get; set; } // P (Present), A (Absent), L (Late)
        public TimeSpan InTime { get; set; } // Example: 09:00
        public TimeSpan OutTime { get; set; } // Example: 18:00
    }

}