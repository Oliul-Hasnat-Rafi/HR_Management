using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class AttendanceSummary
    {
        [Key]
        public Guid Id { get; set; } 
        public Guid EmpId { get; set; } 
        public Guid ComId { get; set; } 
        public int Year { get; set; } 
        public int Month { get; set; } 
        public int PresentDays { get; set; } 
        public int LateDays { get; set; } 
        public int AbsentDays { get; set; } 
    }

}