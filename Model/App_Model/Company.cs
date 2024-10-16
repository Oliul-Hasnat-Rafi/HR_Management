using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.Model.App_Model
{
    public class Company
    {
        [Key]
        public Guid ComId { get; set; }
        [Required]
        public string ComName { get; set; }
        [Range(0, 1)]
        public decimal Basic { get; set; }
        [Range(0, 1)]
        public decimal Hrent { get; set; }
        [Range(0, 1)]
        public decimal Medical { get; set; }
        public bool IsInactive { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Designation> Designations { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Shift> Shifts { get; set; }
    }

}