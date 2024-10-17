using HR_Management.Model.App_Model;

namespace Hr_task.Model.DTO
{
    using HR_Management.Model.App_Model;
    using System.ComponentModel.DataAnnotations;

    namespace Hr_task.Model.DTO
    {
        public class EmployeeDTO
        {
            // Company Information
            [Required(ErrorMessage = "Company ID is required")]
            public Guid ComId { get; set; }

            // Only needed when creating a new company
            public string? CompanyName { get; set; }
            public decimal? BasicPercentage { get; set; }
            public decimal? HRentPercentage { get; set; }
            public decimal? MedicalPercentage { get; set; }

            // Employee Basic Information
            [Required(ErrorMessage = "Employee Code is required")]
            [StringLength(20, MinimumLength = 2, ErrorMessage = "Employee Code must be between 2 and 20 characters")]
            public string EmpCode { get; set; }

            [Required(ErrorMessage = "Employee Name is required")]
            [StringLength(100, MinimumLength = 2, ErrorMessage = "Employee Name must be between 2 and 100 characters")]
            public string EmpName { get; set; }

            [Required(ErrorMessage = "Shift ID is required")]
            public Guid ShiftId { get; set; }

            [Required(ErrorMessage = "Department ID is required")]
            public Guid DeptId { get; set; }

            [Required(ErrorMessage = "Designation ID is required")]
            public Guid DesigId { get; set; }

            [Required(ErrorMessage = "Gender is required")]
            [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Gender must be 'Male', 'Female', or 'Other'")]
            public string Gender { get; set; }

            // Salary Information
            [Required(ErrorMessage = "Gross Salary is required")]
            [Range(0.01, double.MaxValue, ErrorMessage = "Gross Salary must be greater than 0")]
            public decimal GrossSalary { get; set; }

            // Date Information
            [Required(ErrorMessage = "Join Date is required")]
            [DataType(DataType.Date)]
            public DateTime JoinDate { get; set; }
        }

        public class EmployeeResponseDTO
        {
            public Guid EmpId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string Gender { get; set; }
            public string CompanyName { get; set; }
            public string DepartmentName { get; set; }
            public string DesignationName { get; set; }
            public string ShiftName { get; set; }
            public decimal GrossSalary { get; set; }
            public decimal BasicSalary { get; set; }
            public decimal HouseRent { get; set; }
            public decimal Medical { get; set; }
            public decimal Others { get; set; }
            public DateTime JoinDate { get; set; }
            public int ServiceDays { get; set; }
        }

        public class EmployeeListDTO
        {
            public string EmpName { get; set; }
            public DateTime JoinDate { get; set; }
            public int ServiceDays { get; set; }
            public string DepartmentName { get; set; }
            public string DesignationName { get; set; }
            public string ShiftName { get; set; }
        }

        public class EmployeeSalaryDTO
        {
            public string EmpName { get; set; }
            public decimal Gross { get; set; }
            public decimal Basic { get; set; }
            public decimal HouseRent { get; set; }
            public decimal Medical { get; set; }
            public decimal AbsentAmount { get; set; }
            public decimal PayableAmount { get; set; }
            public bool IsPaid { get; set; }
        }

        public class EmployeeAttendanceDTO
        {
            public string EmpName { get; set; }
            public int TotalPresent { get; set; }
            public int TotalAbsent { get; set; }
            public int TotalLate { get; set; }
        }
    
}
}
