using API_Task.Data;
using API_Task.Data.Interface;
using HR_Management.Model.App_Model;
using Hr_task.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hr_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Company
        [HttpGet]
        public async Task<ActionResult> GetCompanies()
        {
            try
            {
                var coompany = await _unitOfWork.Companies.GetAllAsync();
                if (coompany == null) {
                    return Ok("No Company Found");
                }
                return Ok(coompany);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompany(Guid id)
        {
            var company = await _unitOfWork.Companies.GetAsync(x => x.ComId == id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // POST: api/Company
        [HttpPost]
        public async Task<ActionResult> CreateCompany(CompanyDTO company)
        {
            if (company == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var companyDto = new Company
                {
                    ComName = company.ComName,
                    Basic = company.BasicPercentage,
                    Hrent = company.HRentPercentage,
                    Medical = company.MedicalPercentage,
                    IsInactive = company.IsInactive
                };
                 await _unitOfWork.Companies.CreateAsync(companyDto);
                await _unitOfWork.SaveAsync();

                return Ok("Company created successfully.");




            }
            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(Guid id, CompanyDTO company)
        {
            if (id != company.ComId)
            {
                return BadRequest();
            }

           

            try
            {
                var companyinfo = await _unitOfWork.Companies.GetAsync(e => e.ComId == id);
                if (companyinfo == null)
                {
                    return Ok("Did not Found any Company");

                }
                companyinfo.ComId = company.ComId;
                companyinfo.ComName = company.ComName;
                companyinfo.Basic = company.BasicPercentage;
                companyinfo.Medical = company.MedicalPercentage;
                companyinfo.Hrent = company.HRentPercentage;
                companyinfo.IsInactive = company.IsInactive;

                await _unitOfWork.Companies.UpdateAsync(companyinfo);
               await _unitOfWork.SaveAsync();

                return Ok("Update Company");



                
                    
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

            return NoContent();
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            var company = await _unitOfWork.Companies.GetAsync(x => x.ComId == id);

            if (company == null)
            {
                return NotFound();
            }
            _unitOfWork.Companies.DeleteAsync(company);
            await _unitOfWork.SaveAsync();


            return Ok(company);
        }

        
    }
}
