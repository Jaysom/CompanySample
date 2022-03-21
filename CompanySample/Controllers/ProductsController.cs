#nullable disable
using CompanySample.Models;
using CompanySample.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private ILogger<ProductsController> _logger;

        public ProductsController(IProductService service, ILogger<ProductsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return Ok(await _service.GetProducts());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = _service.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("Products/{customerId}")]
        public async Task<ActionResult<IList<Product>>> GetProductsByCustomerId(int customerId)
        {
            var products = await _service.GetProductsByCustomerId(customerId);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }            

            try
            {
                await _service.PutProduct(id, product);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (! await ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex.Message);

                    throw ;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _service.PostProduct(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _service.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            await _service.DeleteProduct(product);

            return NoContent();
        }

        private async Task<bool> ProductExists(int id)
        {
            return await _service.ProductExists(id);
        }
    }
}
