using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Department
    {
        [Key]
        public Guid DeptId { get; set; }

        [Required, StringLength(50)]
        public string DeptName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }

}