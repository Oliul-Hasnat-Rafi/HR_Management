using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Shift
    {
        [Key]
        public Guid ShiftId { get; set; }
        public Guid ComId { get; set; }
        [Required]
        public string ShiftName { get; set; }
        [Required]
        public DateTime empIn { get; set; }
        [Required]
        public DateTime empOut { get; set; }
        [Required]
        public DateTime Late { get; set; }

        [ForeignKey("ComId")]
        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

}