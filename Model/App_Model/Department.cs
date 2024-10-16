using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Department
    {
        [Key]
        public Guid DeptId { get; set; }
        public Guid ComId { get; set; }
        [Required]
        public string DeptName { get; set; }

        [ForeignKey("ComId")]
        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

}