using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Designation
    {
        [Key]
        public Guid DesigId { get; set; }
        public Guid ComId { get; set; }
        [Required]
        public string DesigName { get; set; }

        [ForeignKey("ComId")]
        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

}