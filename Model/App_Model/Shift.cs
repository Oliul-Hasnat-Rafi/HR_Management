using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Shift
    {
        [Key]
        public Guid ShiftId { get; set; }         public Guid ComId { get; set; } 
        public string? ShiftName { get; set; } 
        public TimeSpan InTime { get; set; } 
        public TimeSpan OutTime { get; set; } 
        public TimeSpan LateThreshold { get; set; } 
    }

}