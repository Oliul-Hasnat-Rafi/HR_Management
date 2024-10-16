
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Salary
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ComId { get; set; }
        public Guid EmpId { get; set; }
        [Required]
        public int DtYear { get; set; }
        [Required]
        public int DtMonth { get; set; }
        public decimal Gross { get; set; }
        public decimal Basic { get; set; }
        public decimal Hrent { get; set; }
        public decimal Medical { get; set; }
        public decimal AbsentAmount { get; set; }
        public decimal PayableAmount { get; set; }
        public bool IsPaid { get; set; }
        public decimal PaidAmount { get; set; }
        public Company Company { get; set; }
        public Employee Employee { get; set; }
    }

}
