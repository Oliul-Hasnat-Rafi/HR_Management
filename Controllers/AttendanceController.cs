using API_Task.Data.Interface;
using HR_Management.Model.App_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hr_task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

  
        [HttpPost]
        public async Task<ActionResult> PostAttendance(Attendance atn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var com = await _unitOfWork.Companies.GetAsync(x => x.ComId == atn.ComId);
            if (com == null) return BadRequest("Invalid company ID");

            var emp = await _unitOfWork.Employees.GetAsync(x => x.EmpId == atn.EmpId);
            if (emp == null) return BadRequest("Invalid employee ID");

            if (atn.Id == Guid.Empty)
            {
                atn.Id = Guid.NewGuid();
            }

            await _unitOfWork.Attendances.CreateAsync(atn);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetAttendanceById), new { id = atn.Id }, atn);
        }

        

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendanceById(Guid id)
        {
            var attendance = await _unitOfWork.Attendances.GetAsync(x => x.Id == id);
            if (attendance == null)
            {
                return NotFound($"Attendance record with ID {id} not found");
            }
            return Ok(attendance);
        }

        
        [HttpGet("employee/{empId}")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendanceByEmployee(Guid empId)
        {
            var attendances = await _unitOfWork.Attendances.GetAsync(x => x.EmpId == empId);
            return Ok(attendances);
        }

        [HttpGet("company/{comId}")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendanceByCompany(Guid comId)
        {
            var attendances = await _unitOfWork.Attendances.GetAsync(x => x.ComId == comId);
            return Ok(attendances);
        }

  
        [HttpGet("date-range")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendanceByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var attendances = await _unitOfWork.Attendances.GetAsync(x =>
                x.InTime.Date >= startDate.Date &&
                x.InTime.Date <= endDate.Date);
            return Ok(attendances);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(Guid id, Attendance atn)
        {
            if (id != atn.Id)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAttendance = await _unitOfWork.Attendances.GetAsync(x => x.Id == id);
            if (existingAttendance == null)
            {
                return NotFound($"Attendance record with ID {id} not found");
            }

            await _unitOfWork.Attendances.UpdateAsync(atn);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(Guid id)
        {
            var attendance = await _unitOfWork.Attendances.GetAsync(x => x.Id == id);
            if (attendance == null)
            {
                return NotFound($"Attendance record with ID {id} not found");
            }

             _unitOfWork.Attendances.DeleteAsync(attendance);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}