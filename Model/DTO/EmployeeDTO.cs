using HR_Management.Model.App_Model;

namespace Hr_task.Model.DTO
{
    using HR_Management.Model.App_Model;

    namespace Hr_task.Model.DTO
    {
        public class EmployeeDTO
        {
            public Guid EmpId { get; set; }
            public Guid ComId { get; set; }
            public string? EmpCode { get; set; }
            public string? EmpName { get; set; }
            public Guid ShiftId { get; set; }
            public Guid DeptId { get; set; }
            public Guid DesigId { get; set; }
            public string? Gender { get; set; }
            public decimal GrossSalary { get; set; }
            public DateTime JoinDate { get; set; }

         
            public string? CompanyName { get; set; }
            public decimal? BasicPercentage { get; set; }
            public decimal? HRentPercentage { get; set; }
            public decimal? MedicalPercentage { get; set; }

            
            public Company? Company { get; set; }
            //public decimal BasicSalary => GrossSalary * (Company?.BasicPercentage ?? 0);
            //public decimal HRent => GrossSalary * (Company?.HRentPercentage ?? 0);
            //public decimal Medical => GrossSalary * (Company?.MedicalPercentage ?? 0);
        }
    }
}
