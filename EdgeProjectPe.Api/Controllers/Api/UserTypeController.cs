using EdgeProjectPe.Services.DTO;
using EdgeProjectPe.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdgeProjectPe.Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _usertypeService;
        public UserTypeController(IUserTypeService usertypeService)
        {
            _usertypeService = usertypeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _usertypeService.GetByIdAsync(id);
                if (result == null)
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
        public async Task<ActionResult> CreateUserType(UserTypeDTO usertype)
        {
            if (usertype!=null)
            {
                try
                {
                    await _usertypeService.CreateUserTypeAsync(usertype);
                    return Ok(usertype);

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                }
            }
            return BadRequest();

        }
        [HttpPut]
        public ActionResult UpdateCompany(UserTypeDTO usertype)
        {
            if (usertype!=null)
            {
                try
                {
                    _usertypeService.UpdateUserType(usertype);
                    return Ok(usertype);

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                }
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUserType(int id)
        {
            try
            {
                var result = await _usertypeService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await _usertypeService.DeleteUserTypeAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
