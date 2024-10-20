using API_Task.Data.Interface;
using HR_Management.Model.App_Model;
using HR_Management.Model.DTO;
using Hr_task.Model.DTO;
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


        [HttpGet]
        public async Task<ActionResult> GetEmployees()
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



        [HttpGet("GetEmployeeByid")]
        public async Task<ActionResult> GetEmployeeByid(Guid _Empid)
        {
            try
            {
                var employees = await _unitOfWork.Employees.GetAllAsync(x => x.EmpId == _Empid);

                if (employees == null)
                {
                    return NotFound();
                }

                var attend = await _unitOfWork.Attendances.GetAllAsync(x => x.EmpId == _Empid);


                var res = new
                {
                    employeesinfo = employees,
                    attendinfo = attend
                };

                return Ok(res);

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
                    s.DtMonth == month &&
                    s.DtYear == year);

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
        [HttpPost("Create")]
        public async Task<ActionResult> CreateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
           
                var company = await _unitOfWork.Companies.GetAsync(x => x.ComId == employeeDTO.ComId);
                if (company == null)
                    return BadRequest("Invalid company ID.");

                var existingEmployee = await _unitOfWork.Employees.GetAsync(e =>
                    e.EmpCode == employeeDTO.EmpCode);
                if (existingEmployee != null)
                    return BadRequest("Employee code must be unique within the company.");

                decimal grossSalary = employeeDTO.GrossSalary;
                if (grossSalary <= 0)
                    return BadRequest("Gross salary must be a positive value.");

               
                if (company.Basic + company.Hrent + company.Medical > 100m)
                    return BadRequest("Invalid company salary percentages. Total cannot exceed 100%.");

              
                var employee = new Employee
                {
                    EmpId = Guid.NewGuid(),
                    ComId = employeeDTO.ComId,
                    EmpCode = employeeDTO.EmpCode,
                    EmpName = employeeDTO.EmpName,
                    ShiftId = employeeDTO.ShiftId,
                    DeptId = employeeDTO.DeptId,
                    DesigId = employeeDTO.DesigId,
                    Gender = employeeDTO.Gender,
                    Gross = grossSalary,
                    Basic = grossSalary * (company.Basic / 100m),
                    HRent = grossSalary * (company.Hrent / 100m),
                    Medical = grossSalary * (company.Medical / 100m),
                    Others = grossSalary * ((100m - company.Basic - company.Hrent - company.Medical) / 100m),
                    DtJoin = employeeDTO.JoinDate
                };

                await _unitOfWork.Employees.CreateAsync(employee);
                await _unitOfWork.SaveAsync();

              

                return Ok("Employee created successfully");
            }
            catch (Exception ex)
            {
                

                return StatusCode(500, "An error occurred while processing your request. Please try again later.");
            }
        }

        [HttpDelete("delectEmployee{id}")]
        public async Task<ActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                var employee = await _unitOfWork.Employees.GetAsync(e => e.EmpId == id);
                if (employee == null)
                    return NotFound("Employee not found.");

                 _unitOfWork.Employees.DeleteAsync(employee);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(Guid id, EmployeeDTO employeeDTO)
        {
            try
            {
                var existingEmployee = await _unitOfWork.Employees.GetAsync(e => e.EmpId == id);
                if (existingEmployee == null)
                    return NotFound("Employee not found.");

                var company = await _unitOfWork.Companies.GetAsync(x => x.ComId == employeeDTO.ComId);
                if (company == null)
                    return BadRequest("Invalid company ID.");

                var duplicateEmployee = await _unitOfWork.Employees.GetAsync(e =>
                    e.EmpCode == employeeDTO.EmpCode && e.EmpId != id);
                if (duplicateEmployee != null)
                    return BadRequest("Employee code must be unique within the company.");

              
                decimal grossSalary = employeeDTO.GrossSalary;
                if (grossSalary <= 0)
                    return BadRequest("Gross salary must be a positive value.");

                if (company.Basic + company.Hrent + company.Medical > 100m)
                    return BadRequest("Invalid company salary percentages. Total cannot exceed 100%.");

         
                existingEmployee.ComId = employeeDTO.ComId;
                existingEmployee.EmpCode = employeeDTO.EmpCode;
                existingEmployee.EmpName = employeeDTO.EmpName;
                existingEmployee.ShiftId = employeeDTO.ShiftId;
                existingEmployee.DeptId = employeeDTO.DeptId;
                existingEmployee.DesigId = employeeDTO.DesigId;
                existingEmployee.Gender = employeeDTO.Gender;
                existingEmployee.Gross = grossSalary;
                existingEmployee.Basic = grossSalary * (company.Basic / 100m);
                existingEmployee.HRent = grossSalary * (company.Hrent / 100m);
                existingEmployee.Medical = grossSalary * (company.Medical / 100m);
                existingEmployee.Others = grossSalary * ((100m - company.Basic - company.Hrent - company.Medical) / 100m);
                existingEmployee.DtJoin = employeeDTO.JoinDate;

                await _unitOfWork.Employees.UpdateAsync(existingEmployee);
                await _unitOfWork.SaveAsync();

                return Ok("Employee updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }




        [HttpGet("DeptList")]
        public async Task<ActionResult> GetDept()
        {
            try
            {
                var employees = await _unitOfWork.Departments.GetAllAsync();
                return Ok(employees); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");

            }
        }
        [HttpGet("DesigList")]
        public async Task<ActionResult> GetDesignations()
        {
            try
            {
                var employees = await _unitOfWork.Designations.GetAllAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");

            }
        }

        [HttpGet("ShiftList")]
        public async Task<ActionResult> GetShift()
        {
            try
            {
                var employees = await _unitOfWork.Shifts.GetAllAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");

            }
        }
    }
}
