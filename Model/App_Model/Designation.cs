using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Designation
    {
        [Key]
        public Guid DesigId { get; set; }

        [Required, StringLength(50)]
        public string DesigName { get; set; }

        // Navigation property
        public virtual ICollection<Employee> Employees { get; set; }
    }

}