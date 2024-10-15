using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Attendance
    {
        [Key]
        public Guid Id { get; set; } 
        public Guid ComId { get; set; } 
        public Guid EmpId { get; set; } 
        public DateTime Date { get; set; } 
        public string? AttStatus { get; set; } 
        public TimeSpan InTime { get; set; } 
        public TimeSpan OutTime { get; set; } 
    }

}