using Microsoft.EntityFrameworkCore;
using Oqtane.Modules.Category.Models;
using Oqtane.Models;
namespace Oqtane.Modules.Category
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options) { }

        public DbSet<Models.Category> Categories { get; set; }
    }
}
