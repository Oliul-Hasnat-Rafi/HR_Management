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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var com = await _unitOfWork.Companies.GetAsync(x => x.ComId == atn.ComId);
            if (com == null) return BadRequest("Invalid company ID");

            var emp = await _unitOfWork.Employees.GetAsync(x => x.EmpId == atn.EmpId);
            if (emp == null) return BadRequest("Invalid employee ID");

            await _unitOfWork.Attendances.CreateAsync(atn);
            await _unitOfWork.SaveAsync();

            return Ok(atn);
        }

    }
}
