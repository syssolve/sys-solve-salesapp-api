using EdgeProjectPe.Services.DTO;
using EdgeProjectPe.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdgeProjectPe.Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _saleService.GetByIdAsync(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
        [HttpPost]
        public async Task<ActionResult> CreateSale(SaleDTO sale)
        {
            if (sale!=null)
            {
                try
                {
                    await _saleService.CreateSaleAsync(sale);
                    return Ok(sale);

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                }
            }
            return BadRequest();

        }
        [HttpPut]
        public ActionResult UpdateProduct(SaleDTO sale)
        {
            if (sale!=null)
            {
                try
                {
                    _saleService.UpdateSale(sale);
                    return Ok(sale);

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
