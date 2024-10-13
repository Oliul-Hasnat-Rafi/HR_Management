using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Department
    {
        [Key]
        public Guid DeptId { get; set; } // Primary Key
        public Guid ComId { get; set; } // Foreign Key to Company
        public string? DeptName { get; set; } // Example: HR, IT
    }

}