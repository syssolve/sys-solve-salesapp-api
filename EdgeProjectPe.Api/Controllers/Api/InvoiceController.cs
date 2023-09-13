using EdgeProjectPe.Services.DTO;
using EdgeProjectPe.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdgeProjectPe.Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invService)
        {
            _invoiceService = invService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _invoiceService.GetByIdAsync(id);
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
        public async Task<ActionResult> CreateInvoice(InvoiceDTO invoice)
        {
            if (invoice!=null)
            {
                try
                {
                    await _invoiceService.CreateInvoiceAsync(invoice);
                    return Ok(invoice);

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                }
            }
            return BadRequest();

        }
        [HttpPut]
        public ActionResult UpdateInvoice(InvoiceDTO invoice)
        {
            if (invoice!=null)
            {
                try
                {
                    _invoiceService.UpdateInvoice(invoice);
                    return Ok(invoice);

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
