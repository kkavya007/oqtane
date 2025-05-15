using Microsoft.EntityFrameworkCore;
using ProductModel = Oqtane.Modules.ProductForm.Models.Product;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

    public DbSet<ProductModel> Products { get; set; }
}
