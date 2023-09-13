using EdgeProjectPe.Services.DTO;
using EdgeProjectPe.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdgeProjectPe.Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleInvoiceController : ControllerBase
    {
        private readonly ISaleInvoiceService _saleInvService;
        public SaleInvoiceController(ISaleInvoiceService saleInvService)
        {
            _saleInvService = saleInvService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _saleInvService.GetByIdAsync(id);
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
        public async Task<ActionResult> CreateSaleinvoice(SaleInvoiceDTO saleInv)
        {
            if (saleInv!=null)
            {
                try
                {
                    await _saleInvService.CreateSaleInvoiceAsync(saleInv);
                    return Ok(saleInv);

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                }
            }
            return BadRequest();

        }
        [HttpPut]
        public ActionResult UpdateSaleInvoice(SaleInvoiceDTO saleInv)
        {
            if (saleInv!=null)
            {
                try
                {
                    _saleInvService.UpdateSaleInvoice(saleInv);
                    return Ok(saleInv);

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
