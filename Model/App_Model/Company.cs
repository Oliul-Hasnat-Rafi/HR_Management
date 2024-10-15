using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.Model.App_Model
{
    public class Company
    {
        [Key]
        public Guid ComId { get; set; } 
        public string? ComName { get; set; }
        public decimal BasicPercentage { get; set; }         public decimal HRentPercentage { get; set; } // Ex: 0.3 for 30%
        public decimal MedicalPercentage { get; set; } 
        public bool IsInactive { get; set; } 
    }

}