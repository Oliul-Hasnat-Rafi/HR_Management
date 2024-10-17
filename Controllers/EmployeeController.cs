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

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            try
            {
                var employees = await _unitOfWork.Employees.GetAllAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        //        // GET: api/Employee/ByDepartment?DepId={DepId}
        //        [HttpGet("ByDepartment")]
        //        public async Task<ActionResult> GetEmployeesBYDep(Guid DepId)
        //        {
        //            try
        //            {
        //                if (DepId == Guid.Empty) return BadRequest("Invalid department ID.");

        //                var DepEmp = await _unitOfWork.Employees.GetAsync(x => x.DeptId == DepId);
        //                if (DepEmp == null) return NotFound("No employees found for the given department.");

        //                return Ok(DepEmp);
        //            }
        //            catch (Exception ex)
        //            {
        //                return StatusCode(500, $"Internal Server Error: {ex.Message}");
        //            }
        //        }
        //        [HttpGet("SalaryList")]
        //        public async Task<ActionResult> GetSalaryList(Guid departmentId, int? month, int? year)
        //        {
        //            try
        //            {
        //                // Validate inputs
        //                if (departmentId == Guid.Empty) return BadRequest("Invalid department ID.");
        //                if (month < 1 || month > 12) return BadRequest("Invalid month.");
        //                if (year < 1900 || year > DateTime.Now.Year) return BadRequest("Invalid year.");

        //                // Fetch employees for the given department
        //                var employees = await _unitOfWork.Employees.GetAllAsync(e => e.DesigId == departmentId);

        //                if (employees == null || !employees.Any())
        //                {
        //                    return NotFound("No employees found for the given department.");
        //                }

        //                // Fetch salaries for employees in the given month and year
        //                var salaryList = await _unitOfWork.Salarys.GetAllAsync(s =>
        //                    employees.Any(e => e.EmpId == s.EmpId) &&
        //                    s.Month == month &&
        //                    s.Year == year);

        //                if (salaryList == null || !salaryList.Any())
        //                {
        //                    return NotFound("No salaries found for the given filters.");
        //                }

        //                return Ok(salaryList);
        //            }
        //            catch (Exception ex)
        //            {
        //                return StatusCode(500, $"Internal Server Error: {ex.Message}");
        //            }
        //        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                // Validate company
                var company = await _unitOfWork.Companies.GetAsync(x => x.ComId == employeeDTO.ComId);
                if (company == null)
                    return BadRequest("Invalid company ID.");

                // Validate unique employee code
                var existingEmployee = await _unitOfWork.Employees.GetAsync(e =>
                    e.EmpCode == employeeDTO.EmpCode && e.ComId == employeeDTO.ComId);
                if (existingEmployee != null)
                    return BadRequest("Employee code must be unique within the company.");

                // Validate department
                var department = await _unitOfWork.Departments.GetAsync(d =>
                    d.DeptId == employeeDTO.DeptId && d.ComId == employeeDTO.ComId);
                if (department == null)
                    return BadRequest("Invalid department ID for the specified company.");
// Validate shift
                var shiftValidate = await _unitOfWork.Shifts.GetAsync(d =>
                    d.ShiftId == employeeDTO.ShiftId && d.ComId == employeeDTO.ComId);
                if (department == null)
                    return BadRequest("Invalid department ID for the specified company.");
                    
                // Validate designation
                var designation = await _unitOfWork.Designations.GetAsync(d =>
                    d.DesigId == employeeDTO.DesigId && d.ComId == employeeDTO.ComId);
                if (designation == null)
                    return BadRequest("Invalid designation ID for the specified company.");

                // Calculate salary components based on company percentages
                decimal grossSalary = employeeDTO.GrossSalary;
                var employee = new Employee
                {
                    EmpId = Guid.NewGuid(),
                    ComId = employeeDTO.ComId,
                    EmpCode = employeeDTO.EmpCode,
                    EmpName = employeeDTO.EmpName,
                    ShiftId = employeeDTO.ShiftId,
                    
                    DeptId = employeeDTO.DeptId,
                                        DeptName = department.DeptName,
                                       desigName=designation.DesigName,
shiftName= shiftValidate.ShiftName,

                    DesigId = employeeDTO.DesigId,

                    Gender = employeeDTO.Gender,
                    Gross = grossSalary,
                    Basic = grossSalary * (company.Basic / 100),
                    HRent = grossSalary * (company.Hrent / 100),
                    Medical = grossSalary * (company.Medical / 100),
                    Others = grossSalary * ((100 - company.Basic - company.Hrent - company.Medical) / 100),
                    DtJoin = employeeDTO.JoinDate
                };

                await _unitOfWork.Employees.CreateAsync(employee);
                await _unitOfWork.SaveAsync();

                return CreatedAtAction(nameof(GetEmployees), new { id = employee.EmpId }, employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
