using API_Task.Data.Interface;
using HR_Management.Model.App_Model;
using Hr_task.Model.DTO;
using Hr_task.Model.DTO.Hr_task.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Hr_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

     
        [HttpGet("ByCompany")]
        public async Task<ActionResult> GetEmployees(Guid companyid)
        {
            try
            {
                if (companyid == Guid.Empty) return BadRequest("Invalid company ID.");

                var ComEmp = await _unitOfWork.Employees.GetAsync(x => x.ComId == companyid);
                if (ComEmp == null) return NotFound("No employees found for the given company.");

                return Ok(ComEmp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("ByDepartment")]
        public async Task<ActionResult> GetEmployeesBYDep(Guid DepId)
        {
            try
            {
                if (DepId == Guid.Empty) return BadRequest("Invalid department ID.");

                var DepEmp = await _unitOfWork.Employees.GetAsync(x => x.DeptId == DepId);
                if (DepEmp == null) return NotFound("No employees found for the given department.");

                return Ok(DepEmp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpGet("SalaryList")]
        public async Task<ActionResult> GetSalaryList(Guid departmentId, int? month, int? year)
        {
            try
            {
         
                if (departmentId == Guid.Empty) return BadRequest("Invalid department ID.");
                if (month < 1 || month > 12) return BadRequest("Invalid month.");
                if (year < 1900 || year > DateTime.Now.Year) return BadRequest("Invalid year.");

        
                var employees = await _unitOfWork.Employees.GetAllAsync(e => e.DesigId == departmentId);

                if (employees == null || !employees.Any())
                {
                    return NotFound("No employees found for the given department.");
                }

               
                var salaryList = await _unitOfWork.Salarys.GetAllAsync(s =>
                    employees.Any(e => e.EmpId == s.EmpId) &&
                    s.Month == month &&
                    s.Year == year);

                if (salaryList == null || !salaryList.Any())
                {
                    return NotFound("No salaries found for the given filters.");
                }

                return Ok(salaryList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


      
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                var company = await _unitOfWork.Companies.GetAsync(x => x.ComId == employeeDTO.ComId);

                if (company == null)
                {
                    if (string.IsNullOrEmpty(employeeDTO.CompanyName) ||
                        !employeeDTO.BasicPercentage.HasValue ||
                        !employeeDTO.HRentPercentage.HasValue ||
                        !employeeDTO.MedicalPercentage.HasValue)
                    {
                        return BadRequest("Company not found. Please provide complete company information.");
                    }

                    company = new Company
                    {
                        ComId = employeeDTO.ComId,
                        ComName = employeeDTO.CompanyName,
                        BasicPercentage = employeeDTO.BasicPercentage.Value,
                        HRentPercentage = employeeDTO.HRentPercentage.Value,
                        MedicalPercentage = employeeDTO.MedicalPercentage.Value
                    };

                    await _unitOfWork.Companies.CreateAsync(company);
                }

                var existingEmployee = await _unitOfWork.Employees.GetAsync(e =>
                    e.EmpCode == employeeDTO.EmpCode && e.ComId == employeeDTO.ComId);

                if (existingEmployee != null)
                {
                    return BadRequest("Employee code must be unique.");
                }

                var employee = new Employee
                {
                    EmpId = Guid.NewGuid(),
                    ComId = company.ComId,
                    EmpCode = employeeDTO.EmpCode,
                    EmpName = employeeDTO.EmpName,
                    ShiftId = employeeDTO.ShiftId,
                    DeptId = employeeDTO.DeptId,
                    DesigId = employeeDTO.DesigId,
                    Gender = employeeDTO.Gender,
                    GrossSalary = employeeDTO.GrossSalary,
                    JoinDate = employeeDTO.JoinDate,
                    
                };

                await _unitOfWork.Employees.CreateAsync(employee);
                await _unitOfWork.SaveAsync();

                return Ok("Employee created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
