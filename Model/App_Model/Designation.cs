using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Designation
    {
        [Key]
        public Guid DesigId { get; set; } // Primary Key
        public Guid ComId { get; set; } // Foreign Key to Company
        public string ?DesigName { get; set; } // Example: Intern, Manager
    }

}