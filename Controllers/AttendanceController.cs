using API_Task.Data.Interface;
using HR_Management.Model.App_Model;
using Microsoft.AspNetCore.Mvc;

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
        
            var company = await _unitOfWork.Companies.GetAsync(x => x.ComId == atn.ComId);
            if (company == null)
                return BadRequest("Invalid company ID.");

            var employee = await _unitOfWork.Employees.GetAsync(x => x.EmpId == atn.EmpId);
            if (employee == null)
                return BadRequest("Invalid employee ID.");

            var attendance = new Attendance
            {
                Id = Guid.NewGuid(),
                ComId = atn.ComId,
                EmpId = atn.EmpId,
                DtDate = atn.DtDate,
                AttStatus = atn.AttStatus,
                InTime = atn.InTime,
                OutTime = atn.OutTime,
                
            };

     
            await _unitOfWork.Attendances.CreateAsync(attendance);
            await _unitOfWork.SaveAsync();

            return Ok("Attendance record created successfully.");
        }
    }
}
