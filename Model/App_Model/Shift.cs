using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Shift
    {
        [Key]
        public Guid ShiftId { get; set; } // Primary Key
        public Guid ComId { get; set; } // Foreign Key to Company
        public string? ShiftName { get; set; } // Example: General, Night
        public TimeSpan InTime { get; set; } // Example: 09:00
        public TimeSpan OutTime { get; set; } // Example: 18:00
        public TimeSpan LateThreshold { get; set; } // Example: 09:05
    }

}