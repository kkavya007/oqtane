using Microsoft.AspNetCore.Mvc;
using Oqtane.Modules.ProductForm.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Oqtane.Modules.ProductForm.Controllers
{
    [Route("api/ProductForm/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _db;

        public ProductController(ProductContext db)
        {
            _db = db;
        }

        // GET: api/ProductForm/Product/5
        [HttpGet("{moduleId}")]
        public IActionResult GetProducts(int moduleId)
        {
            var products = _db.Products.Where(p => p.ModuleId == moduleId).ToList();
            if (!products.Any())
                return NotFound("No products found for the given module.");

            return Ok(products);
        }

        // GET: api/ProductForm/Product/5/3
        [HttpGet("{moduleId}/{id}")]
        public IActionResult GetProduct(int moduleId, int id)
        {
            var product = _db.Products.SingleOrDefault(p => p.ModuleId == moduleId && p.ProductId == id);
            if (product == null)
                return NotFound("Product not found.");

            return Ok(product);
        }

        // POST: api/ProductForm/Product
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Oqtane.Modules.ProductForm.Models.Product product)
        {
            if (product == null)
                return BadRequest("Product data cannot be null.");

            if (product.Price < 0 || product.Quantity < 0)
                return BadRequest("Price and Quantity must be non-negative.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { moduleId = product.ModuleId, id = product.ProductId }, product);
        }

        // PUT: api/ProductForm/Product/3
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Oqtane.Modules.ProductForm.Models.Product product)
        {
            if (product == null)
                return BadRequest("Product data cannot be null.");

            if (product.Price < 0 || product.Quantity < 0)
                return BadRequest("Price and Quantity must be non-negative.");

            var existingProduct = await _db.Products.FindAsync(id);
            if (existingProduct == null)
                return NotFound("Product not found.");

            // Update fields
            existingProduct.Name = product.Name;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.Description = product.Description;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;
            existingProduct.ModuleId = product.ModuleId; // Optional depending on whether ModuleId can change

            await _db.SaveChangesAsync();
            return Ok(existingProduct);
        }

        // DELETE: api/ProductForm/Product/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
                return NotFound("Product not found.");

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
