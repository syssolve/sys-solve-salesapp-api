using EdgeProjectPe.Services.DTO;
using EdgeProjectPe.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdgeProjectPe.Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;
        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitService.GetByIdAsync(id);
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
        public async Task<ActionResult> CreateUnit(UnitDTO unit)
        {
            if (unit!=null)
            {
                try
                {
                    await _unitService.CreateUnitAsync(unit);
                    return Ok(unit);

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                }
            }
            return BadRequest();

        }
        [HttpPut]
        public ActionResult UpdateUnit(UnitDTO unit)
        {
            if (unit!=null)
            {
                try
                {
                    _unitService.UpdateUnit(unit);
                    return Ok(unit);

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                }
            }
            return BadRequest();
        }
        [HttpDelete] 
        public async Task<ActionResult> DeletUnit(int id) {
            try
            {
                var result = await _unitService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await _unitService.DeleteUnitAsync(id);                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
