using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Shift
    {
        [Key]
        public Guid ShiftId { get; set; }

        [Required, StringLength(50)]
        public string ShiftName { get; set; }

        [Required]
        public DateTime ShiftStart { get; set; }

        [Required]
        public DateTime ShiftEnd { get; set; }

        [Required]
        public DateTime LateThreshold { get; set; }

        public Guid? ComId { get; set; }
public virtual ICollection<Employee> Employees { get; set; }

    }

}







 