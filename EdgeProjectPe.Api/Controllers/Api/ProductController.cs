using EdgeProjectPe.Services.DTO;
using EdgeProjectPe.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdgeProjectPe.Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _productService.GetByIdAsync(id);
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
        public async Task<ActionResult> CreateProduct(ProductDTO product)
        {
            if (product!=null)
            {
                try
                {
                    await _productService.CreateProductAsync(product);
                    return Ok(product);

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                }
            }
            return BadRequest();

        }
        [HttpPut]
        public ActionResult UpdateProduct(ProductDTO product)
        {
            if (product!=null)
            {
                try
                {
                    _productService.UpdateProduct(product);
                    return Ok(product);

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
