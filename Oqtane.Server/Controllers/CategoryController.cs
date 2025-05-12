using Microsoft.AspNetCore.Mvc;
using Oqtane.Modules.Category.Models;
using Oqtane.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Oqtane.Modules.Category.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryContext _db;

        public CategoryController(CategoryContext db)
        {
            _db = db;
        }

        // GET: api/Category/5
        [HttpGet("{moduleId}")]
        public IActionResult GetCategories(int moduleId)
        {
            var categories = _db.Categories.Where(c => c.ModuleId == moduleId).ToList();
            if (categories == null || !categories.Any())
                return NotFound("No categories found for the given module.");
            return Ok(categories);
        }

        // GET: api/Category/5/3
        [HttpGet("{moduleId}/{id}")]
        public IActionResult GetCategory(int moduleId, int id)
        {
            var category = _db.Categories.SingleOrDefault(c => c.ModuleId == moduleId && c.CategoryId == id);
            if (category == null)
                return NotFound("Category not found.");
            return Ok(category);
        }

        // POST: api/Category/Category
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Models.Category category)
        {
            if (category == null) return BadRequest("Category data cannot be null.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { moduleId = category.ModuleId, id = category.CategoryId }, category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Models.Category category)
        {
            if (category == null) return BadRequest("Category data cannot be null.");

            var existingCategory = await _db.Categories.FindAsync(id);
            if (existingCategory == null) return NotFound("Category not found.");

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            await _db.SaveChangesAsync();
            return Ok(existingCategory);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null) return NotFound("Category not found.");

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
