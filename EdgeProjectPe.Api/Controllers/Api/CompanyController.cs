using EdgeProjectPe.Services.DTO;
using EdgeProjectPe.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace EdgeProjectPe.Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _companyService.GetByIdAsync(id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
        [HttpPost]
        public async Task<ActionResult> CreateCompany(CompanyDTO company)
        {
            if (company!=null)
            {
                try
                {
                    await _companyService.CreateCompanyAsync(company);  
                    return Ok(company);

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                }               
            }
            return BadRequest();
            
        }
        [HttpPut]
        public ActionResult UpdateCompany(CompanyDTO company) {
            if (company!=null)
            {
                try
                {
                    _companyService.UpdateCompany(company);
                    return Ok(company);

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                }
            }
            return BadRequest();
        }
    }
}
