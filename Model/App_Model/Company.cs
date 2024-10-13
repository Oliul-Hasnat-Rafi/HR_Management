using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.Model.App_Model
{
    public class Company
    {
        [Key]
        public Guid ComId { get; set; } // Primary Key
        public string? ComName { get; set; }
        public decimal BasicPercentage { get; set; } // Ex: 0.5 for 50%
        public decimal HRentPercentage { get; set; } // Ex: 0.3 for 30%
        public decimal MedicalPercentage { get; set; } // Ex: 0.15 for 15%
        public bool IsInactive { get; set; } // True or False
    }

}